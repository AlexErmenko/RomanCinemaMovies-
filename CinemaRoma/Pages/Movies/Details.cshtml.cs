using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Movies
{
  public class DetailsModel : PageModel
  {
    private readonly MovieContext _context;

    public Movie Movie { get; set; }

    public DetailsModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Movie = await _context.Movies.Include(m => m.Genre).Include(m => m.Producer).FirstOrDefaultAsync(m => m.Id == id);

      if (Movie == null) return NotFound();
      return Page();
    }
  }
}