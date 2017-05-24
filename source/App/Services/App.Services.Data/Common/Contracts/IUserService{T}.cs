using App.Data.Common.Models;
using App.Data.Models;
using System.Linq;

namespace App.Services.Data.Common.Contracts
{
    public interface IUserService<T> : IBaseDataService<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
        IQueryable<User> GetAll();

        User GetById(string id);
    }
}
