using App.Data.Models;
using App.Services.Data.Common;
using App.Services.Data.Common.Contracts;
using App.Web.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Web.Mvc;
using System.ComponentModel;

namespace App.Web.Areas.Administration.Models
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        private ISanitizer sanitizer;

        public CategoryViewModel()
        {
            sanitizer = new HtmlSanitizerAdapter();
        }

        [HiddenInput]
        [Key]
        public int? Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }
               
       

        //public ICollection<Image> Images { get; set; }

        //public void CreateMappings(IMapperConfiguration configuration)
        //{
        //    configuration.CreateMap<Category, CategoryViewModel>()
        //        .ForMember(a => a.Images, opt => opt.MapFrom(s => s.Images))
        //        .ReverseMap();
        //}
    }
}