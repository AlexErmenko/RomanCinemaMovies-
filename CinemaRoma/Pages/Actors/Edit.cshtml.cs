using System.Linq;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Actors
{
  public class EditModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Actor Actor { get; set; }

    public EditModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);

      if (Actor == null) return NotFound();
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(Actor).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!ActorExists(Actor.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool ActorExists(int id) { return _context.Actors.Any(e => e.Id == id); }
  }
}