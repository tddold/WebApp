using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using App.Web.Areas.Administration.Models;
using App.Web.Infrastructure;

namespace App.Web.Areas.Administration.Controllers
{
    public class ArticlesController : AdministrationController
    {
        private const int ItemsPerPage = 5;
        private readonly IService<Article> articleService;
        //private readonly IBaseDataService<Article> articleService;
        private readonly IArticleService articles;

        public ArticlesController(IService<Article> articleService, IArticleService articles)
        {
            this.articleService = articleService;
            this.articles = articles;
        }

        // GET: Administration/Articles
        public ActionResult Index(int id = 1)
        {
            ArticleInputViewModel viewModels;
            if (HttpContext.Cache["Article_page_" + id] != null)
            {
                viewModels = (ArticleInputViewModel)HttpContext.Cache["Article_page_" + id];
            }
            else
            {
                int page = id;
                int allItemsCount = articles.GetAll().Count();
                int totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
                int itemsToSkip = (page - 1) * ItemsPerPage;

                var articleViewModel = articles
                    .GetAll()
                    .OrderBy(x => x.Title)
                    .ThenBy(x => x.Id)
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .To<ArticleViewModel>()
                    .ToList();

                viewModels = new ArticleInputViewModel
                {
                    CurentPage = page,
                    TotalPages = totalPages,
                    Article = articleViewModel
                };

                HttpContext.Cache["Article_page_" + id] = viewModels;
            }

            return View(viewModels);
        }

        //// GET: Administration/Articles/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Article article = db.Articles.Find(id);
        //    if (article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(article);
        //}

        // GET: Administration/Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Context,ImagePath,IsDeleted")] Article article)
        {
            if (ModelState.IsValid)
            {
                articles.Add(article);
                articles.Save();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        //// GET: Administration/Articles/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Article article = db.Articles.Find(id);
        //    if (article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(article);
        //}

        //// POST: Administration/Articles/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Context,ImagePath,IsDeleted")] Article article)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(article).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(article);
        //}

        //// GET: Administration/Articles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Article article = db.Articles.Find(id);
        //    if (article == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(article);
        //}

        //// POST: Administration/Articles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Article article = db.Articles.Find(id);
        //    db.Articles.Remove(article);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
