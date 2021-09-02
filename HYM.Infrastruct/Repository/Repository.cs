using HYM.Domain.Interfaces;
using HYM.Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HYM.Infrastruct.Repository
{

    /// <summary>
    /// 基础仓储的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly StudyContext _db;

        public Repository(StudyContext db) 
        {
            _db = db;
        }
        public void Add(T obj)
        {
            _db.Set<T>().Add(obj);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> GetAll()
        {
           return _db.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Remove(Guid id)
        {
            _db.Set<T>().Remove(_db.Set<T>().Find(id));
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Update(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}
