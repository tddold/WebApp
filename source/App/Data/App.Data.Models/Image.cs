using App.Data.Common.Models;
using System.Collections;

namespace App.Data.Models
{
    public class Image : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int GategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
