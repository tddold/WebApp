using App.Data.Models;
using System.Linq;

namespace App.Services.Data.Common.Contracts
{
    public interface IArticleService : IBaseDataService<Article>, IImageService
    {
        IQueryable<Article> GetRandomArticles(int count);
    }
}
