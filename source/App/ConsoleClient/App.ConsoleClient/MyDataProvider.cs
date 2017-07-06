using App.Data.Common.Contracts;
using App.Data.Models;
using System;

namespace App.ConsoleClient
{
    public class MyDataProvider
    {
        private Func<IUnitOfWork> unitOfWork;
        private IRepository<Article> articles;
        //private IRepository<HomeArticle> homeArticles;
        //private IRepository<ItemArticle> itemArticles;
        private IRepository<Image> images;
        

        public MyDataProvider(
            Func<IUnitOfWork> unitOfWork,
            IRepository<Article> articles,
            //IRepository<HomeArticle> homeArticles,
            //IRepository<ItemArticle> itemArticles,
            IRepository<Image> images)

        {
            this.UnitOfWork = unitOfWork;
            this.Articles = articles;
            //this.HomeArticles = homeArticles;
            //this.ItemArticles = itemArticles;
            this.Images = images;
            
        }

        public Func<IUnitOfWork> UnitOfWork { get; set; }

        public IRepository<Article> Articles { get; set; }

        //public IRepository<HomeArticle> HomeArticles { get; set; }

        //public IRepository<ItemArticle> ItemArticles { get; set; }

        public IRepository<Image> Images { get; set; }

        
    }
}