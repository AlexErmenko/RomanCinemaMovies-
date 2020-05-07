﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CinemaRoma.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaRoma.Models
{
    public partial class CinemaMovie
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "DateStartRental")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime DateStartRental { get; set; }


        [Display(ResourceType = typeof(Resources), Name = "DateBirth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime DateEndRental { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Cinema")]
        public virtual Cinema Cinema { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Movie")]
        public virtual Movie Movie { get; set; }
    }
}
