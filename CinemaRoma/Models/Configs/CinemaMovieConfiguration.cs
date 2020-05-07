﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaRoma.Models
{
    public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
    {
        public void Configure(EntityTypeBuilder<CinemaMovie> entity)
        {
            entity.HasKey(e => new { e.MovieId, e.CinemaId })
                .HasName("GenreMovies_pk")
                .IsClustered(false);

            entity.Property(e => e.DateEndRental).HasColumnType("date");

            entity.Property(e => e.DateStartRental).HasColumnType("date");

            entity.HasOne(d => d.Cinema)
                .WithMany(p => p.CinemaMovies)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("CinemaMovies_Cinema_Id_fk");

            entity.HasOne(d => d.Movie)
                .WithMany(p => p.CinemaMovies)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("GenreMovies_Movie_Id_fk");
        }
    }
}
