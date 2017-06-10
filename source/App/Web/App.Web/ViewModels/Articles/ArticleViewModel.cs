using System.Collections.Generic;

namespace App.Web.ViewModels.Articles
{
    public class ArticleViewModel
    {
        public ICollection<ArticleDetailsViewModel> Article { get; set; }
    }
}