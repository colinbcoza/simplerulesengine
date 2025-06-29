using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities
{
    public class StorageResults<TId>
    {
        public List<StorageResult<TId>>? Details { get; set; } = new List<StorageResult<TId>>();
    }
}
