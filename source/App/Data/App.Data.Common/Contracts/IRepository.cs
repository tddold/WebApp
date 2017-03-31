using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.Data.Common.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
