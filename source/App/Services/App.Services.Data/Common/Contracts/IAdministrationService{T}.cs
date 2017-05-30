using System.Linq;

namespace App.Services.Data.Common.Contracts
{
    public interface IAdministrationService<T>
        where T : class
    {
        IQueryable<T> GetByPage(int count, int skip);

        T GetById(object id);
    }
}
