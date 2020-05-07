using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Genres
{
  public class DeleteModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Genre Genre { get; set; }

    public DeleteModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Genre = await _context.Genres.FirstOrDefaultAsync(m => m.Id == id);

      if (Genre == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Genre = await _context.Genres.FindAsync(id);

      if (Genre != null)
      {
        _context.Genres.Remove(Genre);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}