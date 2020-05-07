using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.CinemaMovies
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<CinemaMovie> CinemaMovie { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync()
    {
      CinemaMovie = await _context.CinemaMovies.Include(c => c.Cinema).Include(c => c.Movie).ToListAsync();
    }
  }
}