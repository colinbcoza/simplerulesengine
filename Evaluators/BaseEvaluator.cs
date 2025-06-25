using Microsoft.Extensions.Logging;
using SimpleRulesEngine.Entities;

namespace SimpleRulesEngine.Evaluators
{
    public abstract class BaseEvaluator : IEvaluator
    {
        public string Id { get; private set; }

        protected readonly ILogger _logger;
        protected readonly string _evaluatorName;

        public BaseEvaluator(string id, ILogger logger, string evaluatorName) 
        {
            this.Id = Id;
            _logger = logger;
            _evaluatorName = evaluatorName;
        }

        public async Task<EvaluationResult> Evaluate(params object[] arguments)
        {
            try
            {
                return await EvaluateArguments(arguments);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error executing evaluator '{_evaluatorName}' - {exception.Message}", exception, arguments);
                throw;
            }
        }

        protected abstract Task<EvaluationResult> EvaluateArguments(object[] arguments);
    }
}
