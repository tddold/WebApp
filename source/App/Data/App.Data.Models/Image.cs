using App.Data.Common.Models;

namespace App.Data.Models
{
    public class Image: BaseModel<int>
    {
        public string Name { get; set; }

        public int FolderId { get; set; }

        public virtual Folder Folder { get; set; }

        public string Url { get; set; }
    }
}
