using System.Collections.Generic;

namespace App.Web.Areas.Administration.Models
{
    public class ArticleInputViewModel
    {
        public int CurentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<ArticleViewModel> Article { get; set; }
    }
}