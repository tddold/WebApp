﻿using App.Services.Data.Common.Contracts;
using System;
using App.Data.Models;
using App.Data.Common.Contracts;
using System.Web;
using System.IO;
using System.Linq;

namespace App.Services.Data.Common
{
    public class HomeArticleService : BaseDataService<HomeArticle>, IHomeArticleService
    {
        private readonly IRepository<HomeArticle> homeArticle;

        public HomeArticleService(IRepository<HomeArticle> homeArticle)
            : base(homeArticle)
        {
            this.homeArticle = homeArticle;
        }

        public IQueryable<HomeArticle> AllArticle(int count)
        {
            return this.homeArticle
                .All
                .OrderBy(a => Guid.NewGuid());
        }

        public IQueryable<HomeArticle> GetRandomArticles(int count)
        {
            return this.homeArticle
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

            var homeArticle = (HomeArticle)instance;
            var fileName = Path.GetFileName(photo.FileName);
            var filePath = Path.Combine(absolutePath, fileName);
            photo.SaveAs(filePath);

            homeArticle.Article.ImagePath = relativePath + filePath;
            this.homeArticle.Save();
        }
    }
}
