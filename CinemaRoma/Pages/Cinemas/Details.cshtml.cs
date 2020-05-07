using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Cinemas
{
  public class DetailsModel : PageModel
  {
    private readonly MovieContext _context;

    public Cinema Cinema { get; set; }

    public DetailsModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Cinema = await _context.Cinemas.FirstOrDefaultAsync(m => m.Id == id);

      if (Cinema == null) return NotFound();
      return Page();
    }
  }
}