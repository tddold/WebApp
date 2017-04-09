using App.Data.Models.Contracts;

namespace App.Data.Models
{
    public class HomeArticle : IDbModel
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
