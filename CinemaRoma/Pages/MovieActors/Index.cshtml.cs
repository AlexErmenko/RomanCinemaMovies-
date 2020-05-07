using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.MovieActors
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<MovieActor> MovieActor { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync()
    {
      MovieActor = await _context.MovieActors.Include(m => m.Actor).Include(m => m.Movie).ToListAsync();
    }
  }
}