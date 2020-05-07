using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Movies
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<Movie> Movie { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync()
    {
      Movie = await _context.Movies.Include(m => m.Genre).Include(m => m.Producer).ToListAsync();
    }
  }
}