    using App.Data.Common.Models;
    using System.Linq;

namespace App.Services.Data.Common.Contracts
{
    public interface IBaseDataService<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        void Add(T item);

        void Delete(int id);

        IQueryable<T> GetAll();

        T GetById(int id);

        T GetById(object id);

        void Update(T entity);

        void Save();

        void Dispose();
    }
}
