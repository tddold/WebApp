using App.Services.Data.Common.Contracts;
using System.Linq;
using App.Data.Models;
using System.Web;
using App.Data.Common.Contracts;
using System.IO;

namespace App.Services.Data.Common
{
    public class GallerlyService : IGalleryService
    {
        private readonly IRepository<Image> repository;

        public GallerlyService(IRepository<Image> repository)
        {
            this.repository = repository;
        }

        public void Add(Image item)
        {
            repository.Add(item);
            repository.Save();
        }

        public void Delete(Image model)
        {
            repository.Delete(model);
            repository.Save();
        }

        public Image Find(int id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Image> GetAll()
        {
            return repository.All;
        }

        public void Update(Image model)
        {
            repository.Update(model);
        }

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

    }
}
