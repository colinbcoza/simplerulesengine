using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities
{
    public class AttributeType
    {
        public string Key { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string Description { get; set; } = string.Empty;
    }
}
