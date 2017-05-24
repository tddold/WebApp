using App.Data.Common.Models;

namespace App.Data.Models
{
    public class HomeArticle : BaseModel<int>
    {
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
