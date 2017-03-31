﻿using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [MaxLength(100), MinLength(5)]
        public string Title { get; set; }

        [MaxLength(500), MinLength(5)]
        public string Context { get; set; }
    }
}
