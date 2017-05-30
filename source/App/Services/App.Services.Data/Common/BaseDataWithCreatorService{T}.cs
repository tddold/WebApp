using App.Common;
using App.Data.Common.Contracts;
using App.Data.Common.Models;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Linq;

namespace App.Services.Data.Common
{
    public class BaseDataWithCreatorService<T> : BaseDataService<T>, IBaseDataWithCreatorService<T>
        where T : class, IDeletableEntity, IAuditInfo, IEntityWithCreator
    {
        public BaseDataWithCreatorService(IRepository<T> dataSet, IRepository<User> users)
            : base(dataSet)
        {
            Users = users;
        }

        protected IRepository<User> Users { get; set; }

        public IQueryable<T> GetAllByUser(string userId)
        {
            return Data
                .All
                .Where(u => u.UserId == userId);

        }

        public void Delete(object id, string userId)
        {
            var user = Users.GetById(userId);
            var isAdmin = user.Roles.Any(u => u.RoleId == GlobalConstants.AdministratorRoleName);
            var training = Data.GetById(id);
            if (training == null)
            {
                throw new InvalidOperationException($"No entity with provided id ({id}) found.");
            }

            if (training.UserId != userId && !isAdmin)
            {
                throw new InvalidOperationException("Cannot delete entity. Unauthorized request.");
            }

            Data.Delete(training);
            Data.Save();
        }

    }
}
