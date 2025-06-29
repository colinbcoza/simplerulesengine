using SimpleRulesEngine.LogicEngine;

namespace SimpleRulesEngine.Entities
{
    
    public class LogicConfig
    {
        public Operator.Type Operator { get; set; }
        public List<RuleEvaluatorConfiguration> EvaluatorConfigurations { get; set; }
    }
}