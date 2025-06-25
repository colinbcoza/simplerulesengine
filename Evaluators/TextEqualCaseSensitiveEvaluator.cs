using Microsoft.Extensions.Logging;
using SimpleRulesEngine.Entities;

namespace SimpleRulesEngine.Evaluators
{
    public class TextEqualCaseSensitiveEvaluator : TextEqualEvaluator
    {
        public TextEqualCaseSensitiveEvaluator(string id, ILogger logger) 
            : base(id, logger, nameof(TextEqualCaseSensitiveEvaluator)) 
        {
            this.comparer = StringComparison.Ordinal;
        }
    }
}
