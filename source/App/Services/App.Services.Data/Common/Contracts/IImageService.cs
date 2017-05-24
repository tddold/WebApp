using System.Web;

namespace App.Services.Data.Common.Contracts
{
    public interface IImageService
    {
        void SaveImage(HttpPostedFileBase photo, object instance, string absolutePath, string relativePath);
    }
}
