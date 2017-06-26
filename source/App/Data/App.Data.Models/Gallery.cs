using App.Data.Common.Models;
using System.Collections.Generic;

namespace App.Data.Models
{
    public class Gallery : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Category> categories;
        public Gallery()
        {
            this.categories = new HashSet<Category>();
        }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
