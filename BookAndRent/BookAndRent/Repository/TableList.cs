using BookAndRent.Models.Intefaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BookAndRent.Repository
{
    public class TableList<T> : ITableList<T> where T: IIdenitifiable
    {
        private ICollection<T> Collection { get; set; }
        private Type DbMappedType { get; set; }

        public event Action<T, Type> ElementAdded;
        public event Action<T, Type> ElementUpdated;

        public TableList(ICollection<T> collection, Type dbMappedType)
        {
            Collection = collection;
            DbMappedType = dbMappedType;
        }

        public int Count => Collection.Count;

        public bool IsReadOnly => Collection.IsReadOnly;

        public void Add(T item)
        {
            Collection.Add(item);
            ElementAdded.Invoke(item, DbMappedType);
        }

        public void Replace(int index, T item)
        {
            var oldItem = Collection.ElementAt(index);
            Collection.Remove(oldItem);
            Collection.Add(item);
            ElementUpdated.Invoke(item, DbMappedType);
        }

        public void Clear() => Collection.Clear();

        public bool Contains(T item) => Collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Collection.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => Collection.GetEnumerator();

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => Collection.GetEnumerator();
    }
}
