using App.Data.Common.Contracts;
using App.Data.Common.Models;
using App.Services.Data.Common.Contracts;
using System.Linq;

namespace App.Services.Data.Common
{
    public abstract class Service<T> : IService<T>
      where T : BaseModel<int>
    {
        private readonly IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Add(T model)
        {
            repository.Add(model);
            repository.Save();
        }

        public void Delete(T model)
        {
            repository.Delete(model);
            repository.Save();
        }

        public T Find(int id)
        {
            return repository.GetById(id);
        }

        public IQueryable<T> GetAll()
        {
            return repository.All;
        }

        public void Update(T model)
        {
            repository.Update(model);
        }
    }
}
