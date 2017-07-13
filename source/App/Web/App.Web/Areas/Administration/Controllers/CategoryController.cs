using App.Data.Models;
using App.Services.Data.Common.Contracts;
using App.Web.Areas.Administration.Models;
using App.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Controllers
{
    public class CategoryController : Controller
    {
        private const int ItemsPerPage = 5;
        private readonly ICategoryService categories;
        

        public CategoryController(ICategoryService categories)
        {
            this.categories = categories;
            
        }

        // GET: Administration/Category
        public ActionResult Index(int id = 1)
        {

            CategoryInputViewModel viewModels;
            //if (HttpContext.Cache["Category_page_" + id] != null)
            //{
            //    viewModels = (CategoryInputViewModel)HttpContext.Cache["Category_page_" + id];
            //}
            //else
            //{
                int page = id;
                int allItemsCount = categories.GetAll().Count();
                int totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
                int itemsToSkip = (page - 1) * ItemsPerPage;

                var categoryViewModel = categories
                    .GetAll()
                    .OrderBy(x => x.Name)
                    .ThenBy(x => x.Id)
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .To<CategoryViewModel>()
                    .ToList();

                viewModels = new CategoryInputViewModel
                {
                    CurentPage = page,
                    TotalPages = totalPages,
                    Category = categoryViewModel
                };

                HttpContext.Cache["Category_page_" + id] = viewModels;

            //}

            return View(viewModels);
        }

        // GET: Administration/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Administration/Category/Create
        public ActionResult Create()
        {
            //var galleryViewModel = galleries.GetAll().ToList();

            //CategoryViewModel viewModel = new CategoryViewModel
            //{
            //    Gallery = galleryViewModel
            //};

            //return View(viewModel);
            return View();


        }

        // POST: Administration/Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name, IsDeleted")] Category category)
        {
            if (ModelState.IsValid)
            {
                categories.Add(category);
                categories.Save();
                return RedirectToAction("Index");
            }

            //return View(article);
            return this.Json(new[] { categories });

        }

        // GET: Administration/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                categories.Update(category);
                categories.Save();
                return RedirectToAction("Index");
            }
            //return View(article);
            return this.Json(new[] { categories });

        }

        // GET: Administration/Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            categories.Delete(category);
            categories.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
