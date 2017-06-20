using App.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
  public  class Folder : BaseModel<int>
    {
        public Folder()
        {
            this.ChildFolders = new HashSet<Folder>();
            this.Images = new HashSet<Image>();
        }
     
        public string Name { get; set; }

        public Nullable<int> ParentId { get; set; }

        public string Path { get; set; }

        public virtual ICollection<Folder> ChildFolders { get; set; }

        public virtual Folder Parent { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
