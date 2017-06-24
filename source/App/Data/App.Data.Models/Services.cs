using App.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class Services : BaseModel<int>, IAuditInfo, IDeletableEntity
    {
        [MaxLength(100), MinLength(5)]
        public string Title { get; set; }

        public string Context { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
