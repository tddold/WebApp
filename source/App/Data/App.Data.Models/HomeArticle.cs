﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Models
{
    public class HomeArticle
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
