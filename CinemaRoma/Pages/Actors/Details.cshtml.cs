using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Actors
{
  public class DetailsModel : PageModel
  {
    private readonly MovieContext _context;

    public Actor Actor { get; set; }

    public DetailsModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);

      if (Actor == null) return NotFound();
      return Page();
    }
  }
}