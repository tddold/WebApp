using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using App.Data.Common.Models;
using System;

namespace App.Data.Models
{
    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifieOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
