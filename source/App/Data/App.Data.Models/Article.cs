using App.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class Article : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        [MaxLength(100), MinLength(5)]
        public string Title { get; set; }

        public string Context { get; set; }
    }
}
