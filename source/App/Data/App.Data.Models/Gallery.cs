using App.Data.Models.Contracts;
using System.Collections.Generic;

namespace App.Data.Models
{
    public class Gallery:IDbModel
    {
        private ICollection<Image> images;

        public Gallery()
        {
            this.images = new HashSet<Image>();
        }

        public int Id { get; set; }

        public virtual ICollection<Image> Images
        {
            get => images;
            set => images = value;
        }
    }
}
