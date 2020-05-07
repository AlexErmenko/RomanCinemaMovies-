using System.Linq;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.MovieActors
{
  public class EditModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public MovieActor MovieActor { get; set; }

    public EditModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      MovieActor = await _context.MovieActors.Include(m => m.Actor)
                                 .Include(m => m.Movie)
                                 .FirstOrDefaultAsync(m => m.MovieId == id);

      if (MovieActor == null) return NotFound();
      ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "FirstName");
      ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(MovieActor).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!MovieActorExists(MovieActor.MovieId))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool MovieActorExists(int id) { return _context.MovieActors.Any(e => e.MovieId == id); }
  }
}