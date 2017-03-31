namespace App.Data.Models
{
    public class ItemArticle
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
