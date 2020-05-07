using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.MovieActors
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext context;

    public IList<MovieActor> MovieActor { get; set; }

    public IndexModel(MovieContext context) { this.context = context; }

    public async Task OnGetAsync()
    {
      MovieActor = await context.MovieActors.Include(m => m.Actor).Include(m => m.Movie).ToListAsync();
    }
  }
}