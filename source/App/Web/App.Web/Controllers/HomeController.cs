using App.Services.Data.Common.Contracts;
using App.Web.Infrastructure;
using App.Web.ViewModels.Articles;
using App.Web.ViewModels.Home;
using App.Web.ViewModels.HomeArticles;
using System.Linq;
using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class HomeController : BaseController
    {
        private int cashTime = 30 * 60;

        private readonly IArticleService articles;
        //private IBaseDataService<Article> articles;

        public HomeController(IArticleService articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {          
            HomeViewModel homeViewModel = this.GetHomeViewModel();
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private HomeViewModel GetHomeViewModel()
        {
            var topArticles = articles
                .GetRandomArticles(3)
                .To<ArticleDetailsViewModel>()
                .ToList();

            var allArticles = articles
                .GetAll()
                .To<ArticleDetailsViewModel>()
                .ToList();

           

            var homeViewModel = new HomeViewModel
            {
                TopArticles = topArticles,
                AllArticles = allArticles
            };

            return homeViewModel;
        }
    }
}