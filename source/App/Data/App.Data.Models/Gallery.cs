using App.Data.Common.Models;
using System.Collections.Generic;

namespace App.Data.Models
{
    public class Gallery : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        public int CategoriId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
