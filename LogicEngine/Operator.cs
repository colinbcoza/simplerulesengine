using SimpleRulesEngine.Entities;

namespace SimpleRulesEngine.LogicEngine
{
    public static class Operator
    {
        public enum Type
        {
            True,
            False,
            And,
            Or,
            Not
        }

        public async static Task<bool> True(Func<Task<EvaluationResult>> evaluator)
            => evaluator().GetAwaiter().GetResult().Result == ResultType.Success;

        public async static Task<bool> False(Func<Task<EvaluationResult>> evaluator)
            => evaluator().GetAwaiter().GetResult().Result != ResultType.Success;

        public async static Task<bool> And(params Func<Task<EvaluationResult>>[] evaluators)
        {
            foreach (var evaluator in evaluators)
            {
                if (!(evaluator().GetAwaiter().GetResult().Result == ResultType.Success)) return false;
            }
            return true;
        }

        public async static Task<bool> Or(params Func<Task<EvaluationResult>>[] evaluators)
        {
            foreach (var evaluator in evaluators)
            {
                if ((evaluator().GetAwaiter().GetResult().Result == ResultType.Success)) return true;
            }
            return false;
        }

        public async static Task<bool> Not(Func<Task<EvaluationResult>> evaluator)
            => evaluator().GetAwaiter().GetResult().Result != ResultType.Success;
        
      
    }
}
