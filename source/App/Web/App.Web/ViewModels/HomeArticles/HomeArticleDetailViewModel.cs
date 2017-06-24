using App.Data.Models;
using App.Services.Data.Common;
using App.Services.Data.Common.Contracts;
using App.Web.Infrastructure;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace App.Web.ViewModels.HomeArticles
{
    //public class HomeArticleDetailViewModel : IMapFrom<HomeArticle>, IHaveCustomMappings
    //{
    //    private ISanitizer sanitaizer;

    //    public HomeArticleDetailViewModel()
    //    {
    //        this.sanitaizer = new HtmlSanitizerAdapter();
    //    }

    //    [HiddenInput]
    //    [Key]
    //    public int Id { get; set; }

    //    [Display(Name = "Title")]
    //    public string Title { get; set; }

    //    [Display(Name = "Context")]
    //    public string Context { get; set; }

    //    [Display(Name = "Url")]
    //    public string ImagePath { get; set; }

    //    public int ArticleId { get; set; }

    //    public void CreateMappings(IMapperConfiguration configuration)
    //    {
    //        configuration.CreateMap<HomeArticle, HomeArticleDetailViewModel>()
    //            .ForMember(a => a.Title, opt => opt.MapFrom(s => s.Article.Title))
    //            .ReverseMap();

    //        configuration.CreateMap<HomeArticle, HomeArticleDetailViewModel>()
    //            .ForMember(a => a.Context, opt => opt.MapFrom(s => s.Article.Context))
    //            .ReverseMap();

    //        configuration.CreateMap<HomeArticle, HomeArticleDetailViewModel>()
    //            .ForMember(a => a.ImagePath, opt => opt.MapFrom(s => s.Article.ImagePath))
    //            .ReverseMap();
    //    }
    //}
}