using App.Data.Common.Models;
using System.Collections.Generic;

namespace App.Data.Models
{
    public class Gallery: BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        private ICollection<Image> images;

        public Gallery()
        {
            this.images = new HashSet<Image>();
        }

        public virtual ICollection<Image> Images
        {
            get => images;
            set => images = value;
        }
    }
}
