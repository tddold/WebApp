using App.Data.Common.Contracts;
using App.Data.Common.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace App.Data.Common
{
    public class EfGenericRepository<T> : IRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        private readonly AppDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        public EfGenericRepository(AppDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is requires to use tis repository.");
            }

            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> All
        {
            get
            {
                return dbSet.Where(c => !c.IsDeleted);
            }
        }

        public IQueryable<T> AllWithDeleted => dbSet;

        public IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includerExpression)
        {
            return this.All.Include(includerExpression);
        }

        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            DbEntityEntry entry = dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            entry.State = state;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
