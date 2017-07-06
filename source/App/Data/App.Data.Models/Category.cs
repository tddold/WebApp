using App.Data.Common.Models;
using System.Collections.Generic;

namespace App.Data.Models
{
    public class Category : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;

        public Category()
        {
            this.images = new HashSet<Image>();
        }

        public string Name { get; set; }
        

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
