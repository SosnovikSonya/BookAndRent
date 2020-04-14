using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;

namespace BookAndRent.Repository
{
    public interface ITableList<T> : ICollection<T> where T : IUpdatable
    {
        event Action<T, Type> ElementAdded;
        event Action<T, Type> ElementUpdated;
        void Replace(int index, T item);
    }
}
