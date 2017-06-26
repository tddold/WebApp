using App.Data.Models;
using App.Services.Data.Common.Contracts;
using App.Web.Areas.Administration.Models;
using App.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Controllers
{
    public class CategoryController : Controller
    {
        private const int ItemsPerPage = 5;
        private readonly ICategoryService categories;
        private readonly IGalleryService galleries;

        public CategoryController(ICategoryService categories, IGalleryService galleries)
        {
            this.categories = categories;
            this.galleries = galleries;
        }

        // GET: Administration/Category
        public ActionResult Index(int id = 1)
        {

            CategoryInputViewModel viewModels;
            if (HttpContext.Cache["Category_page_" + id] != null)
            {
                viewModels = (CategoryInputViewModel)HttpContext.Cache["Category_page_" + id];
            }
            else
            {
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

            }

            return View(viewModels);
        }

        // GET: Administration/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Category/Create
        public ActionResult Create()
        {
            var galleryViewModel = galleries.GetAll().ToList();

            CategoryViewModel viewModel = new CategoryViewModel
            {
                Gallery = galleryViewModel
            };

            return View(viewModel);

           
        }

        // POST: Administration/Category/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,GaleryId,Gallery, IsDeleted")] Category category)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
