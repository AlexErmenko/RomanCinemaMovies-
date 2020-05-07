using System.Linq;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.CinemaMovies
{
  public class EditModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public CinemaMovie CinemaMovie { get; set; }

    public EditModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      CinemaMovie = await _context.CinemaMovies.Include(c => c.Cinema)
                                  .Include(c => c.Movie)
                                  .FirstOrDefaultAsync(m => m.MovieId == id);

      if (CinemaMovie == null) return NotFound();
      ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "Address");
      ViewData["MovieId"]  = new SelectList(_context.Movies, "Id", "Description");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(CinemaMovie).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!CinemaMovieExists(CinemaMovie.MovieId))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool CinemaMovieExists(int id) { return _context.CinemaMovies.Any(e => e.MovieId == id); }
  }
}