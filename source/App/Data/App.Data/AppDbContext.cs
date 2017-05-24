using App.Data.Common.Contracts;
using App.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Linq;
using App.Data.Common.Models;

namespace App.Data
{
    public class AppDbContext : IdentityDbContext<User>, IDbContextSaveChanges
    {
        public AppDbContext()
            : base("WebAppDb", throwIfV1Schema: false)
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<HomeArticle> HomeArticles { get; set; }

        public virtual IDbSet<ItemArticle> ItemArticles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Gallery> Galleries { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public override int SaveChanges()
        {
            ApplyAuditInfoRoles();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRoles()
        {
            foreach (var entry in ChangeTracker
                .Entries()
                .Where(
                e =>
                e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifieOn = DateTime.UtcNow;
                }
            }
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    this.OnArticleCreating(modelBuilder);
        //    this.HomeArticlesCreating(modelBuilder);
        //    this.ItemArticlesCreating(modelBuilder);
        //    this.ImagesCreating(modelBuilder);
        //}

        //private void ImagesCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Image>()
        //        .Property(im => im.Url)
        //        .IsRequired();
        //}

        //private void ItemArticlesCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ItemArticle>()
        //        .Property(i => i.ArticleId)
        //        .IsRequired();

        //    modelBuilder.Entity<ItemArticle>()
        //        .Property(i => i.ImageId)
        //        .IsRequired();
        //}

        //private void OnArticleCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Article>()
        //        .Property(a => a.Title)
        //        .IsRequired();

        //    modelBuilder.Entity<Article>()
        //        .Property(a => a.Context)
        //        .IsRequired();
        //}

        //private void HomeArticlesCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HomeArticle>()
        //        .Property(h => h.ArticleId)
        //        .IsRequired();
        //}

    }
}
