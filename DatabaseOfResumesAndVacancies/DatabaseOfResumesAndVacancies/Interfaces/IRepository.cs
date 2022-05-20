using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T Entity);
        void Delete(int Id);
        void Delete(T Entity);
        void Clear();
        void Modify(int Id, T NewItem);
        T Get(int Id);
        T GetByPosition(int Position);
        List<T> GetAll();
        List<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        List<T> GetAll(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}