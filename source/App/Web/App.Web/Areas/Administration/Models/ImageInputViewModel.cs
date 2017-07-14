using System.Collections.Generic;

namespace App.Web.Areas.Administration.Models
{
    public class ImageInputViewModel
    {
        public int CurentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<ImageViewModel> Image { get; set; }
    }
}