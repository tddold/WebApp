using App.Data.Models;
using App.Services.Data.Common;
using App.Services.Data.Common.Contracts;
using App.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Models
{
    public class ArticleViewModel: IMapFrom<Article>
    {
        private ISanitizer sanitizer;

        public ArticleViewModel()
        {
            sanitizer = new HtmlSanitizerAdapter();
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(5)]
        public string Title { get; set; }

        [AllowHtml]
        public string Context { get; set; }
    }
}