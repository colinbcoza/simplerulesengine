using SimpleRulesEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Operators
{
    public class SimpleSemanticEngine : ISemanticEngine
    {
        //semantic types
        public StorageManager<string, string> Tags = new StorageManager<string, string>();
        public StorageManager<AttributeType, string> Attributes = new StorageManager<AttributeType, string>();
        public StorageManager<Query,string> Queries = new StorageManager<Query, string>();

        public 
        //attributes
        private Dictionary<Guid, Attribute> _attributesTypes = new Dictionary<Guid, Attribute>();
        public List<Attribute> Attributes { get => _attributesTypes.Values.ToList(); }
        public void UpsertAttributes(List<Attribute> tags)
        {
            foreach (var tag in tags)
            {

            }
        }
        public void RemoveAttributes(List<string> attributeKeys)
        {

        }

        //queries

        public List<string> Keys { get; set; }
        private List<Query> Queries { get; set; }
        public SimpleSemanticEngine()
        {
        }


    }
}
