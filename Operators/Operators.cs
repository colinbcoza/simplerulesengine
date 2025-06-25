using SimpleRulesEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Operators
{
    internal static class Operators
    {
        static async Task<EvaluationResult> True (params )
        static async Task<EvaluationResult> And (params IEvaluator[] arguments) 
        {
            var result = new EvaluationResult();
            result.Result = ResultType.Failure;

            foreach (var evaluator in arguments)                
            {
                var evaluatorResult = evaluator.Evaluate()
            }
        }
    }
}
