using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities
{
    public class RuleEvaluatorConfiguration
    {
        public string Id { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEvaluator Evaluator { get; set; } = null;
        public List<string> ParameterSequenceMap { get; set; } = new List<string>();        
    }
}
