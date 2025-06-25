using SimpleRulesEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine
{
    public interface IEvaluator
    {
        public string Id { get; }
        public Task<EvaluationResult> Evaluate(params object[] arguments);
    }
}
