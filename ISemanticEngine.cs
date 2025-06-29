using SimpleRulesEngine.Entities;
using SimpleRulesEngine.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine
{
    public interface ISemanticEngine
    {
        IStorageManager<string, string> Tags { get; }
        IStorageManager<string, AttributeType> Attributes { get; }
        IStorageManager<string, Query> Queries { get; }

        public List<string> GetAttributeList { get; set; }
        Task<QueryResult> EvaluateQuery(string queryId, Dictionary<string, object> criteria, CancellationToken? cancellationToken = null);

    }
}
