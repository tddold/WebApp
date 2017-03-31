using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() 
            : base("WebAppDb")
        {
        }

        public virtual IDbSet<Article>  Articles { get; set; }

        public virtual IDbSet<HomeArticle> HomeArticles { get; set; }

        public virtual IDbSet<ItemArticle> ItemArticles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Gallery> Galleries { get; set; }
    }
}
