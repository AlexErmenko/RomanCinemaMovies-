using System.Linq;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Movies
{
  public class EditModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Movie Movie { get; set; }

    public EditModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Movie = await _context.Movies.Include(m => m.Genre).Include(m => m.Producer).FirstOrDefaultAsync(m => m.Id == id);

      if (Movie == null) return NotFound();
      ViewData["GenreId"]    = new SelectList(_context.Genres, "Id", "Id");
      ViewData["ProducerId"] = new SelectList(_context.Directors, "Id", "FirstName");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(Movie).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!MovieExists(Movie.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool MovieExists(int id) { return _context.Movies.Any(e => e.Id == id); }
  }
}