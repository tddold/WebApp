using App.Data.Models;
using App.Services.Data.Common;
using App.Services.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Controllers
{
  
    public class ImageBrowserController : Controller
    {

        private const int ThumbnailHeight = 80;
        private const int ThumbnailWidth = 80;

        private readonly IImageService images;

        public ImageBrowserController(IImageService images)
        {
            this.images = images;
        }

        //// GET: Administration/ImageBrowser
        //public ActionResult Read()
        //{
        //    return View();
        //}

        //// GET: Administration/ImageBrowser/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Administration/ImageBrowser/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Administration/ImageBrowser/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Administration/ImageBrowser/Upload
        //public ActionResult Upload()
        //{
        //    return View();
        //}

        //// POST: Administration/ImageBrowser/Upload
        //[HttpPost]
        //public ActionResult Upload(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Administration/ImageBrowser/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Administration/ImageBrowser/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Administration/ImageBrowser/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Administration/ImageBrowser/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //public ActionResult Image(string path)
        //{
        //    var files = new ImagesService();
        //    var image = files.ImageByPath(path);
        //    if (image != null)
        //    {
        //        const string contentType = "image/png";
        //        return File(image.Image1, contentType);
        //    }
        //    throw new HttpException(404, "File Not Found");
        //}

        //public ActionResult Create(string path, ImageBrowserEntry entry)
        //{
        //    var files = new FilesRepository();
        //    var folder = files.GetFolderByPath(path);
        //    if (folder != null)
        //    {
        //        files.CreateDirectory(folder, entry.Name);
        //        return Content("");
        //    }
        //    throw new HttpException(403, "Forbidden");
        //}

        //public ActionResult Destroy(string path, ImageBrowserEntry entry)
        //{
        //    var files = new FilesRepository();
        //    if (entry.EntryType == ImageBrowserEntryType.File)
        //    {
        //        var image = files.ImageByPath(Path.Combine(path, entry.Name));
        //        if (image != null)
        //        {
        //            files.Delete(image);
        //            return Content("");
        //        }
        //    }
        //    else
        //    {
        //        var folder = files.GetFolderByPath(Path.Combine(path, entry.Name));
        //        if (folder != null)
        //        {
        //            files.Delete(folder);
        //            return Content("");
        //        }
        //    }
        //    throw new HttpException(404, "File Not Found");
        //}

        //public JsonResult Read(string path)
        //{
        //    var files = new FilesRepository();

        //    var folders = files.Folders(path);

        //    var images = files.Images(path);

        //    return Json(folders.Concat(images));
        //}

        //public ActionResult Thumbnail(string path)
        //{
        //    //TODO:Add security checks

        //    var files = new FilesRepository();
        //    var image = files.ImageByPath(path);
        //    if (image != null)
        //    {
        //        var desiredSize = new ImageSize { Width = ThumbnailWidth, Height = ThumbnailHeight };

        //        const string contentType = "image/png";

        //        var thumbnailCreator = new ThumbnailCreator(new FitImageResizer());

        //        using (var stream = new MemoryStream(image.Image1.ToArray()))
        //        {
        //            return File(thumbnailCreator.Create(stream, desiredSize, contentType), contentType);
        //        }
        //    }
        //    throw new HttpException(404, "File Not Found");
        //}

        //public ActionResult Upload(string path, HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        var files = new FilesRepository();
        //        var parentFolder = files.GetFolderByPath(path);
        //        if (parentFolder != null)
        //        {
        //            files.SaveImage(parentFolder, file);
        //            return Json(
        //                new
        //                {
        //                    name = Path.GetFileName(file.FileName)
        //                }
        //            , "text/plain");
        //        }
        //    }
        //    throw new HttpException(404, "File Not Found");
        //}
    }
}
