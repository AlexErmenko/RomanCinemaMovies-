﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CinemaRoma.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaRoma.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            CinemaMovies = new HashSet<CinemaMovie>();
        }

        public int Id { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "Location")]
        public string Location { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Address")]
        public string Address { get; set; }

        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; }

        public override string ToString() => $"{Location}";


    }
}
