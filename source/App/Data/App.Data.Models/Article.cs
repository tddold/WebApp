using App.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class Article : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;

        public Article()
        {
            this.images = new HashSet<Image>();
        }

        [MaxLength(100), MinLength(5)]
        public string Title { get; set; }

        public string Context { get; set; }

        public string ImagePath { get; set; }
    }
}
