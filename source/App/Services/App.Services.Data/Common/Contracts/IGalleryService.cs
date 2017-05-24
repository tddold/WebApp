using App.Data.Models;

namespace App.Services.Data.Common.Contracts
{
    public interface IGalleryService : IBaseDataService<Gallery>, IImageService
    {
    }
}