using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace fifi.domain
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Detach(T entity);
    }
}
