using App.Data.Models;
using App.Web.Infrastructure;
using System;
using AutoMapper;
using App.Services.Data.Common.Contracts;
using App.Services.Data.Common;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.Web.ViewModels.Articles
{
    public class ArticleDetailsViewModel : IMapFrom<Article>
    {
        private ISanitizer sanitaizer;

        public ArticleDetailsViewModel()
        {
            this.sanitaizer = new HtmlSanitizerAdapter();
        }

        [HiddenInput]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Context")]
        public string Context { get; set; }

        //[Display(Name = "Url")]
        //public string ImagePath { get; set; }

        //public void CreateMappings(IMapperConfiguration configuration)
        //{
        //    throw new NotImplementedException();
        //}

    }
}