using System.Collections.Generic;

namespace App.Data.Models
{
    public class Gallery
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
