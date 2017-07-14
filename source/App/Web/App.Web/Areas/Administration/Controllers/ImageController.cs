using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using App.Web.Areas.Administration.Models;
using App.Services.Data.Common.Contracts;
using App.Web.Infrastructure;
using App.Data.Models;

namespace App.Web.Areas.Administration.Controllers
{
    public class ImageController : AdministrationController
    {
        private const int ItemsPerPage = 5;
        private const int ThumbnailHeight = 80;
        private const int ThumbnailWidth = 80;

        private readonly IImageService images;

        public ImageController(IImageService images)
        {
            this.images = images;
        }

        // GET: Administration/ImageViewModels
        public ActionResult Index(int id = 1)
        {
            ImageInputViewModel viewModels;
            
            int page = id;
            int allItemsCount = images.GetAll().Count();
            int totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            int itemsToSkip = (page - 1) * ItemsPerPage;

            var imageViewModel = images
                .GetAll()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<ImageViewModel>()
                .ToList();

            viewModels = new ImageInputViewModel
            {
                CurentPage = page,
                TotalPages = totalPages,
                Image = imageViewModel
            };
            

            return View(viewModels);
        }

        // GET: Administration/ImageViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Image image = images.GetById(id);
            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        // GET: Administration/ImageViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/ImageViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Url,GategoryId")] Image image)
        {
            if (ModelState.IsValid)
            {
                images.Add(image);
                images.Save();
                return RedirectToAction("Index");
            }

            //return View(image);
            return Json(new[] { images });
        }

        // GET: Administration/ImageViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Image image = images.GetById(id);
            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        // POST: Administration/ImageViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Url,GategoryId")] Image image)
        {
            if (ModelState.IsValid)
            {
                images.Update(image);
                images.Save();
                return RedirectToAction("Index");
            }

            //return View(image);
            return Json(new[] { images });
        }

        // GET: Administration/ImageViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Image image = images.GetById(id);
            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        // POST: Administration/ImageViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Image image = images.GetById(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            images.Delete(image);
            images.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                images.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
