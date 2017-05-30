using App.Data.Common.Contracts;
using App.Data.Models;
using App.Services.Data.Common.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Services.Data.Common
{
    public class ItemArticleService : BaseDataService<ItemArticle>, IItemArticleService
    {
        private readonly IRepository<ItemArticle> itemArticle;

        public ItemArticleService(IRepository<ItemArticle> itemArticle)
            : base(itemArticle)
        {
            this.itemArticle = itemArticle;
        }

        public void SaveImage(HttpPostedFileBase photo, object instance, string absolutePath, string relativePath)
        {
            if (!(instance is Article))
            {
                throw new ArgumentException("Categories service accepts only categories.");
            }

            var itemArticle = (ItemArticle)instance;
            var fileName = Path.GetFileName(photo.FileName);
            var filePath = Path.Combine(absolutePath, fileName);
            photo.SaveAs(filePath);

            itemArticle.Article.ImagePath = relativePath + filePath;
            this.itemArticle.Save();
        }
    }
}
