using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities
{
    public abstract class StorageManager<TData,Tid> 
    {
        protected Dictionary<Guid, TData> _items = new Dictionary<Guid, TData>();
        public List<TData> Tags { get => _items.Values.ToList(); }
        public void UpsertTags(List<TData> items)
        {
            //ValidateItems(items);

            foreach (var item in items)
            {

            }
        }

        //protected abstract ValidateItems(List<TData> items);

        public void Remove(List<Tid> keys)
        {

        }

    }
}
