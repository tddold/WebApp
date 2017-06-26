using App.Services.Data.Common.Contracts;
using System.Linq;
using App.Data.Models;
using System.Web;
using App.Data.Common.Contracts;
using System.IO;
using System;

namespace App.Services.Data.Common
{
    public class GallerlyService : IGalleryService
    {
        private readonly IRepository<Gallery> repository;

        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GallerlyService(IRepository<Gallery> repository)
        {
            this.repository = repository;
        }

        //public void Add(Image item)
        //{
        //    repository.Add(item);
        //    repository.Save();
        //}

        //public void Delete(Image model)
        //{
        //    repository.Delete(model);
        //    repository.Save();
        //}

        //public Image Find(int id)
        //{
        //    return repository.GetById(id);
        //}

        //public IQueryable<Image> GetAll()
        //{
        //    return repository.All;
        //}

        //public void Update(Image model)
        //{
        //    repository.Update(model);
        //}

        public void SaveImage(HttpPostedFileBase photo, object instance, string absolutePath, string relativePath)
        {
            if (photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/App_Data/"),
                    fileName
                    );

                photo.SaveAs(path);
            }
        }

        public void Add(Gallery item)
        {
            repository.Add(item);
            repository.Save();
        }

        public void Delete(int id)
        {
            var galleryForDeleting = repository.GetById(id);

            repository.Delete(galleryForDeleting);
            repository.Save();
        }

        public void Delete(Gallery entity)
        {
            repository.Delete(entity);
            repository.Save();
        }

        IQueryable<Gallery> IBaseDataService<Gallery>.GetAll()
        {
           return repository.All;
        }

        public Gallery GetById(int id)
        {
            return repository.GetById(id);
        }

        public Gallery GetById(object id)
        {
            return repository.GetById(id);
        }

        public void Update(Gallery entity)
        {
            repository.Update(entity);
        }

        public void Save()
        {
            repository.Save();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
