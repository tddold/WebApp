using App.Data.Models.Contracts;

namespace App.Data.Models
{
    public class Image:IDbModel
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }
}
