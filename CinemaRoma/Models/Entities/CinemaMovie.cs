﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace CinemaRoma.Models
{
    public partial class CinemaMovie
    {
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime DateStartRental { get; set; }
        public DateTime DateEndRental { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Movie Movie { get; set; }
    }
}