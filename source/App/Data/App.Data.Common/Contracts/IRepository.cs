using App.Data.Common.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace App.Data.Common.Contracts
{
    public interface IRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllWithDeleted { get; }

        IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includerExpression);

        T GetById(int id);

        T GetById(object id);

        void Add(T entity);

        T Delete(T entity);

        void Update(T entity);

        void Save();

        void Dispose();
    }
}
