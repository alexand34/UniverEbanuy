using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARoom.Common.Model;
using ARoom.Data.IRepository;

namespace ARoom.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly aRoomContext _context;
        public BaseRepository(aRoomContext context)
        {
            this._context = context;
        }

        public virtual IEnumerable<T> Query()
        {
            return this._context.Set<T>();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public async void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Add(T entity)
        { 
            this._context.Set<T>().Add(entity);
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
