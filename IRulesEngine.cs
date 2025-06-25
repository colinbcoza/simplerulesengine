using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine
{
    public interface IRulesEngine
    {
        Task<Dictionary<string, object>> EvaluateQuery(string queryId, Dictionary<string, string> criteria, CancellationToken? cancellationToken = null);
    }
}
