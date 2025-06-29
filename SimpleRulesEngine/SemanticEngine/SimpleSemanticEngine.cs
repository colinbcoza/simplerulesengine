using SimpleRulesEngine.Entities;
using SimpleRulesEngine.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.SemanticEngine
{
    public class SimpleSemanticEngine : ISemanticEngine
    {
        //semantic types
        private readonly StorageManager<string, string> _tags = new StorageManager<string, string>();
        private readonly StorageManager<string, AttributeType> _attributes = new StorageManager<string, AttributeType>();
        private readonly StorageManager<string, Query> _queries = new StorageManager<string, Query>();

        public SimpleSemanticEngine()
        {
        }

        public List<string> GetAttributeList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IStorageManager<string, string> Tags => _tags;

        public IStorageManager<string, AttributeType> Attributes => _attributes;

        public IStorageManager<string, Query> Queries => _queries;

        public async Task<QueryResult> EvaluateQuery(string queryId, Dictionary<string, object> attributeParams, CancellationToken? cancellationToken = null)
        {
            var result = new QueryResult();
            var executionQuery = await Queries.Get(queryId);
            if (executionQuery == null) throw new ArgumentException($"Unknown Query Id - {queryId}");

            var executionResult = await executionQuery.Evaluate(attributeParams);

            return result;
        }
    }
}
