using App.Data.Models;
using System.Linq;
using System.Web;

namespace App.Services.Data.Common.Contracts
{
    public interface IImageService:IBaseDataService<Image>
    {
        IQueryable<Image> GetAllImages(int count);

        void SaveImage(HttpPostedFileBase photo, object instance, string absolutePath, string relativePath);
    }
}
