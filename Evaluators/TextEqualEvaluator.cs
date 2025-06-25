using Microsoft.Extensions.Logging;
using SimpleRulesEngine.Entities;

namespace SimpleRulesEngine.Evaluators
{
    public class TextEqualEvaluator : BaseEvaluator
    {
        protected StringComparison comparer = StringComparison.OrdinalIgnoreCase;

        public TextEqualEvaluator(string id, ILogger logger, string evaluatorName = nameof(TextEqualEvaluator)) 
            : base (id, logger, evaluatorName) {}

        protected override async Task<EvaluationResult> EvaluateArguments(object[] arguments)
        {
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));
            if (arguments.Length <= 1) throw new ArgumentOutOfRangeException(nameof(arguments), $"{_evaluatorName} requires minimum of 2 arguments" );

            var compareTo = (string)arguments[0];

            for (int paramIndex = 1; paramIndex < arguments.Length; paramIndex++)
            {
                if (!string.Equals((string)arguments[paramIndex], compareTo, comparer))
                {
                    return new EvaluationResult
                    {
                        Description = _evaluatorName,
                        Result = ResultType.Failure
                    };
                }
            }

            return new EvaluationResult
            {
                Description = _evaluatorName,
                Result = ResultType.Success
            };

        }
    }
}
