﻿using System.Collections.Generic;

namespace App.Web.Areas.Administration.Models
{
    public class CategoryInputViewModel
    {
        public int CurentPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<CategoryViewModel> Category { get; set; }
    }
}