using System.Collections.Generic;
using Sample.Core.Contracts;

namespace Sample.Core.Repository
{
    public class StaticListRepository<T, TKey> : BaseRepository<T, TKey> where T : IEntity<TKey>, new()
    {
         private static readonly IList<T> Items = new List<T>();

        public override IEnumerable<T> All()
        {
            return Items;
        }

        public override void Delete(T item)
        {
            Items.Remove(item);
        }

        public override T Update(T item)
        {
            Items.Remove(Get(item.Id));
            Items.Add(item);
            return Get(item.Id);
        }

        public override T Add(T item)
        {
            Items.Add(item);
            return Get(item.Id);
        }
    }
}