using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using lab5.Data.IRepository;
using lab5.Data.Models;

namespace lab5.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected lab8Context RepositoryContext { get; set; }

        public BaseRepository(lab8Context repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> Query()
        {
            return this.RepositoryContext.Set<T>();
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Add(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }
    }
}
