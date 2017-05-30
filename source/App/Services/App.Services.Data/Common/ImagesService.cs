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
    public class ImagesService : IImageService
    {
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
