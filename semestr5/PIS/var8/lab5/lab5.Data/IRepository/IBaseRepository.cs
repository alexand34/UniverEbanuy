using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace lab5.Data.IRepository
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Query();
        void Update(T entity);
        void Remove(T entity);
        void Add(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
