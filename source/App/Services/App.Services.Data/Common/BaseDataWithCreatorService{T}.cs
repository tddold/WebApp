using App.Data.Common.Contracts;
using App.Data.Common.Models;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Data.Common
{
    public class BaseDataWithCreatorService<T> : BaseDataService<T>, IBaseDataWithCreatorService<T>
        where T : class, IDeletableEntity, IAuditInfo, IEntityWithCreator
    {
        public BaseDataWithCreatorService(IRepository<T> dataSet, IRepository<User> users)
            :base(dataSet)
        {
            Users = users;
        }

        protected IRepository<User> Users { get; set; }

        public void Delete(object id, string userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllByUser(string uderId)
        {
            throw new NotImplementedException();
        }
    }
}
