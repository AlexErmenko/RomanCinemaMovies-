using System.ComponentModel.DataAnnotations;
using CinemaRoma.Properties;

namespace CinemaRoma.Models
{
    public class MovieActor
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Actor")]
        public virtual Actor Actor { get; set; }

        [Display(ResourceType = typeof(Resources), Name = "Movie")]
        public virtual Movie Movie { get; set; }
    }
}