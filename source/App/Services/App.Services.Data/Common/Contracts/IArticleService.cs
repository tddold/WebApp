using App.Data.Models;
using System.Linq;

namespace App.Services.Data.Common.Contracts
{
    public interface IArticleService : IBaseDataService<Article>
    {
        IQueryable<Article> GetRandomArticles(int count);
    }
}
