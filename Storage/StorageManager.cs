using SimpleRulesEngine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Storage
{
    public class StorageManager<TId, TData> : IStorageManager<TId, TData>
    {
        protected Dictionary<TId, TData> _items = new Dictionary<TId, TData>();

        public async virtual Task<Dictionary<TId, TData>> GetAll() => _items;

        public async virtual Task<Dictionary<TId, TData>> GetItems(List<TId> ids)
        {
            var result = new Dictionary<TId, TData>();

            foreach (var id in ids)
            {
                if (_items.ContainsKey(id)) result.Add(id, _items[id]);
            }

            return result;
        }
        public async virtual Task<TData> Get(TId id)
        {
            return (_items.ContainsKey(id)) 
                ? _items[id] 
                : default(TData);
        }

        public async virtual Task<StorageResults<TId>> Upsert(Dictionary<TId, TData> items)
        {
            //ValidateItems(items);
            var result = new StorageResults<TId>();  

            foreach (var item in items)
            {
                var itemResult = new StorageResult<TId> { Id = item.Key, Success = true };

                if (_items.ContainsKey(item.Key))
                {
                    _items[item.Key] = item.Value;
                    itemResult.Detail = "updated";
                }
                else 
                {
                    _items.Add(item.Key, item.Value);
                    itemResult.Detail = "inserted";
                }

                result.Details.Add(itemResult);
            }

            return result;
        }

        public async virtual Task<StorageResults<TId>> Remove(List<TId> keys)
        {
            var result = new StorageResults<TId>();

            foreach (var key in keys)
            {
                var itemResult = new StorageResult<TId> { Id = key, Success = true };

                if (_items.ContainsKey(key))
                {
                    _items.Remove(key);
                    itemResult.Success = true;
                    itemResult.Detail = "updated";
                }
                else
                {
                    itemResult.Success = false;
                    itemResult.Detail = "does not exist";
                }

                result.Details.Add(itemResult);
            }

            return result;
        }

    }
}
