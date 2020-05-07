using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Producers
{
  public class DetailsModel : PageModel
  {
    private readonly MovieContext _context;

    public Director Director { get; set; }

    public DetailsModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Director = await _context.Directors.FirstOrDefaultAsync(m => m.Id == id);

      if (Director == null) return NotFound();
      return Page();
    }
  }
}