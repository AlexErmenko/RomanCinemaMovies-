using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.MovieActors
{
  public class DetailsModel : PageModel
  {
    private readonly MovieContext context;

    public MovieActor MovieActor { get; set; }

    public DetailsModel(MovieContext context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      MovieActor = await context.MovieActors.Include(m => m.Actor)
                                .Include(m => m.Movie)
                                .FirstOrDefaultAsync(m => m.MovieId == id);

      if (MovieActor == null) return NotFound();
      return Page();
    }
  }
}
