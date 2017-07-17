using App.Data.Models;
using App.Services.Data.Common;
using App.Services.Data.Common.Contracts;
using App.Web.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Models
{

    public class ImageViewModel : IMapFrom<Image>
    {
        private ISanitizer sanitizer;

        public ImageViewModel()
        {
            sanitizer = new HtmlSanitizerAdapter();
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int GategoryId { get; set; }

        public virtual Category Category { get; set; }

        //[Required]
        //public HttpPostedFileBase File { get; set; }

        public IEnumerable<HttpPostedFileBase> File { get; set; }
    }

}