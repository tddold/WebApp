using App.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace App.Data.Common
{
    public class EfGenericRepository<T> : IRepository<T>
        where T : class
    {
        public EfGenericRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return DbSet
                .Where(filterExpression)
                .ToList();
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
        
        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
