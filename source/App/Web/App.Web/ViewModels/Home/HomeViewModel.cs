using App.Web.ViewModels.Articles;
using App.Web.ViewModels.HomeArticles;
using System.Collections.Generic;

namespace App.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public ICollection<ArticleDetailsViewModel> TopArticles { get; set; }

        public ICollection<ArticleDetailsViewModel> AllArticles { get; set; }

        //public ICollection<HomeArticleDetailViewModel> HomeArticles { get; set; }

    }
}