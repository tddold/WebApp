using App.Data.Common.Contracts;
using App.Data.Common.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace App.Services.Data.Common
{
    public abstract class BaseDataService<T> : IBaseDataService<T>
            where T : class, IDeletableEntity, IAuditInfo
    {
        //private readonly IRepository<T> dataSet;

        public BaseDataService(IRepository<T> dataSet)
        {
            Data = dataSet;
        }

        public IRepository<T> Data { get; set; }

        public virtual void Add(T item)
        {
            Data.Add(item);
            Data.Save();
        }

        public virtual void Delete(int id)
        {
            DbEntityEntry entity = Data.GetById(id) as DbEntityEntry;
            if (entity == null)
            {
                throw new InvalidOperationException("No entity with provided id found.");
            }

            Data.Delete(entity as T);
            Data.Save();
        }

        public void Dispose()
        {
            Data.Dispose();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Data.All;
        }

        public virtual T GetById(int id)
        {
            return Data.GetById(id);
        }

        public T GetById(object id)
        {
            return Data.GetById(id);
        }

        public void Save()
        {
            Data.Save();
        }

        public void Update(T entity)
        {
            Data.Update(entity);
        }
    }
}
