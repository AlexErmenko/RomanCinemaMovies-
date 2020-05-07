﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CinemaRoma.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaRoma.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "GenreName")]
        [MinLength(3)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
