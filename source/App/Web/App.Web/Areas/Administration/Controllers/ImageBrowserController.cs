using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Controllers
{
    public class ImageBrowserController : Controller
    {
        // GET: Administration/ImageBrowser
        public ActionResult Read()
        {
            return View();
        }

        // GET: Administration/ImageBrowser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/ImageBrowser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/ImageBrowser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/ImageBrowser/Upload
        public ActionResult Upload()
        {
            return View();
        }

        // POST: Administration/ImageBrowser/Upload
        [HttpPost]
        public ActionResult Upload(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administration/ImageBrowser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administration/ImageBrowser/Edit/5
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

        // GET: Administration/ImageBrowser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administration/ImageBrowser/Delete/5
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
