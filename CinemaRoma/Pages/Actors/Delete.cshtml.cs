using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Actors
{
  public class DeleteModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Actor Actor { get; set; }

    public DeleteModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) { return NotFound(); }

      Actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);

      if (Actor == null) { return NotFound(); }

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) { return NotFound(); }

      Actor = await _context.Actors.FindAsync(id);

      if (Actor != null)
      {
        _context.Actors.Remove(Actor);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}