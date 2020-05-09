using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaRoma.Models
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> entity)
        {
            entity.HasKey(e => new {e.MovieId, e.ActorId})
                .HasName("MovieActor_pk")
                .IsClustered(false);

            entity.ToTable("MovieActor");

            entity.HasOne(d => d.Actor)
                .WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.ActorId)
                .HasConstraintName("MovieActor_Actor_Id_fk");

            entity.HasOne(d => d.Movie)
                .WithMany(p => p.MovieActor)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("MovieActor_Movie_Id_fk");
        }
    }
}