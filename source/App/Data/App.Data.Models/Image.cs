using App.Data.Common.Models;

namespace App.Data.Models
{
    public class Image: BaseModel<int>
    {
        public string Url { get; set; }
    }
}
