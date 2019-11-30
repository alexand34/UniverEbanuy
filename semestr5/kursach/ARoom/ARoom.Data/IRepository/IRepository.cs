using System;
using System.Collections.Generic;
using System.Text;
using ARoom.Common.Model;

namespace ARoom.Data.IRepository
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> Query();
        T GetById(int id);
        void Remove(T entity);
        void Update(T entity);
        void Add(T entity);
        void SaveChanges();
    }
}
