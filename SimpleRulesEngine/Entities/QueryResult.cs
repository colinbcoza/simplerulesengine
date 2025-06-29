using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities
{
    public class QueryResult
    {
        public ResultType Result { get; set; }
        public List<EvaluationResult> EvaluationResults { get; set; } = new List<EvaluationResult>();
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    }
}
