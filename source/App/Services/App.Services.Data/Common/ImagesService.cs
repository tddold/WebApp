using App.Data.Common.Contracts;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Services.Data.Common
{
    public class ImagesService : BaseDataService<Image>, IImageService
    {
        private readonly IRepository<Image> image;

        public ImagesService(IRepository<Image> image)
            :base(image)
        {
            this.image = image;
        }

        public IEnumerable<Image> Images(string path)
        {
            return Images(path);

            
        }

        public Image ImageByPath(string path)
        {
            //var fileName = Path.GetFileName(path);
            //var folder = FolderService.GetFolderByPath(Path.GetDirectoryName(path));

            //return image.All.SingleOrDefault(img => img.Name == fileName && img.FolderId == folder.Id);
            throw new NotImplementedException();
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

        public IQueryable<Image> GetAllImages(int count)
        {
            return this.image
                .All
                .OrderBy(a => a.Id)
                .Take(count);
        }
    }
}
