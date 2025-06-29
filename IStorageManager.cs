using SimpleRulesEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine
{
    public interface IStorageManager<TId, TData>
    {
        Task<Dictionary<TId, TData>> GetAll();
        Task<Dictionary<TId, TData>> GetItems(List<TId> ids);
        Task<TData> Get(TId id);
        Task<StorageResults<TId>> Upsert(Dictionary<TId, TData> items);
        Task<StorageResults<TId>> Remove(List<TId> keys);
    }
}
