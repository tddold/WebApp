using App.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Data.Common.Contracts
{
    interface IBaseDataWithCreatorService<T>: IBaseDataService<T>
        where T: class, IDeletableEntity, IAuditInfo, IEntityWithCreator
    {
        void Delete(object id, string userId);

        IQueryable<T> GetAllByUser(string uderId);
    }
}
