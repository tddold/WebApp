using App.Data.Common.Contracts;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Services.Data.Common
{
    public class ArticleService : BaseDataService<Article>, IArticleService
    {
        private readonly IRepository<Article> article;

        public ArticleService(IRepository<Article> article)
            : base(article)
        {
            this.article = article;
        }

        public IQueryable<Article> AllArticle(int count)
        {
            return this.article
                .All
                .OrderBy(a => Guid.NewGuid());
        }

        public IQueryable<Article> GetRandomArticles(int count)
        {
            return this.article
                .All
                .OrderBy(a => a.Id)
                .Take(count);
        }

        public void SaveImage(HttpPostedFileBase photo, object instance, string absolutePath, string relativePath)
        {
            if (!(instance is Article))
            {
                throw new ArgumentException("Categories service accepts only categories.");
            }

            var article = (Article)instance;
            var fileName = Path.GetFileName(photo.FileName);
            var filePath = Path.Combine(absolutePath, fileName);
            photo.SaveAs(filePath);

            article.ImagePath = relativePath + filePath;
            this.article.Save();
        }
    }
}
