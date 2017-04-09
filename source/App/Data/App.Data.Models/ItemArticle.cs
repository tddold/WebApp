using App.Data.Models.Contracts;

namespace App.Data.Models
{
    public class ItemArticle:IDbModel
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
