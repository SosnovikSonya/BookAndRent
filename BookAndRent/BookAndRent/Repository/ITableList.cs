using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;

namespace BookAndRent.Repository
{
    public interface ITableList<T> where T : IIdenitifiable
    {
        event Action<T> ElementAdded;
        event Action<T> ElementUpdated;
        event Action<T> ElementDeleted;
        //void Replace(int index, T item);
        T FindById(int id);
        void Add(T element);
        void Delete(int id);
        void Modify(T element);
        IEnumerable<T> Search(Func<T, bool> searchPredicate);
    }
}
