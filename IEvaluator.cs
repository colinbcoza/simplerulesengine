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
        public string Id { get; set; }
        public List<string> GetParameterNames();
        public Task<EvaluationResult> Evaluate(Dictionary<string, object> attributes, params object[] arguments);
    }
}
