using Microsoft.Extensions.Logging;
using SimpleRulesEngine.Entities;
using SimpleRulesEngine.Evaluators;

namespace SimpleRulesEngine.LogicEngine
{
    public class SimpleRule : BaseEvaluator, IRule
    {
        public string Description { get; set; }
        public List<RuleEvaluatorConfiguration> Evaluators { get; set ; }
        public List<LogicConfig> RuleLogic { get; set; }
        public Dictionary<string, object> Configuration { get; set; }

        public override List<string> GetParameterNames()
        {
            var result = new List<string>();

            foreach (var rulePart in RuleLogic) 

                foreach (var partDefinition in rulePart.EvaluatorConfigurations) 

                    foreach (var attributeKey in partDefinition.ParameterSequenceMap) 

                        if (!result.Contains(attributeKey)) result.Add(attributeKey);

            return result;
        }

        public SimpleRule(string id, ILogger logger, string evaluatorName = nameof(TextEqualEvaluator))    
            : base(id, logger, evaluatorName) { }

        protected override async Task<EvaluationResult> EvaluateArguments(Dictionary<string, object> attributes, params object[] arguments)
        {
            var result = new EvaluationResult();

            foreach (var evaluation in RuleLogic)
            {
                var evaluators = WireUpEvaluatorParameters(evaluation.EvaluatorConfigurations, attributes, arguments);
                //todo move loginc to logic engine
                switch (evaluation.Operator)
                {
                    case Operator.Type.True:
                        result.Result = (await Operator.True(evaluators.First())) 
                            ? ResultType.Success
                            : ResultType.Failure;
                        break;

                    case Operator.Type.False:
                        result.Result = (await Operator.False(evaluators.First()))
                            ? ResultType.Failure
                            : ResultType.Success;

                        break;

                    case Operator.Type.Or:
                        result.Result = (await Operator.Or(evaluators))
                            ? ResultType.Failure
                            : ResultType.Success;
                        break;

                    case Operator.Type.And:
                        result.Result = (await Operator.And(evaluators))
                            ? ResultType.Failure
                            : ResultType.Success;
                        break;

                    case Operator.Type.Not:
                        result.Result = (await Operator.False(evaluators.First()))
                            ? ResultType.Failure
                            : ResultType.Success;
                        break;

                    default:
                        throw new InvalidOperationException("Rule logic operator unknown.");
                }
            }
            return result;            
        }

        //protected override Task<EvaluationResult> EvaluateArguments(Dictionary<string, object> attributes, params object[] arguments)
        //{
        //    throw new NotImplementedException();
        //}

        private Func<Task<EvaluationResult>>[] WireUpEvaluatorParameters(
            List<RuleEvaluatorConfiguration> evaluators, Dictionary<string, object> attributes, 
            params object[] parameters)
        {
            var result = new List<Func<Task<EvaluationResult>>>();

            foreach (var evaluatorConfig in evaluators) 
            {               
                var sequencedParamKeys = evaluatorConfig.ParameterSequenceMap;
                var evaluationParams = new List<object>();

                foreach (var mapKey in evaluatorConfig.ParameterSequenceMap)
                {
                    var attribParam = attributes.FirstOrDefault(item => item.Key == mapKey).Value;
                    //var configParam = attributes.FirstOrDefault(item => item.Key == parameterName).Value;

                    //todo: deal with assignments on both lists in rule configuration
                    evaluationParams.Add(attribParam /*?? configParam*/);
                }

                result.Add(() => evaluatorConfig.Evaluator.Evaluate(attributes, evaluationParams.ToArray()));   
            }

            return result.ToArray();
        }
    }
}
