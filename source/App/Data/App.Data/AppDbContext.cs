using App.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace App.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() 
            : base("WebAppDb", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article>  Articles { get; set; }

        public virtual IDbSet<HomeArticle> HomeArticles { get; set; }

        public virtual IDbSet<ItemArticle> ItemArticles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Gallery> Galleries { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
