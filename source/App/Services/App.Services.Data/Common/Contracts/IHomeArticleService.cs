using App.Data.Models;
using System.Linq;

namespace App.Services.Data.Common.Contracts
{
    public interface IHomeArticleService : IBaseDataService<HomeArticle>, IImageService
    {
        IQueryable<HomeArticle> GetRandomArticles(int count);
    }
}
