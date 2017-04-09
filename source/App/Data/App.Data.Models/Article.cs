using App.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class Article:IDbModel
    {
        public int Id { get; set; }

        [MaxLength(100), MinLength(5)]
        public string Title { get; set; }
                
        public string Context { get; set; }
    }
}
