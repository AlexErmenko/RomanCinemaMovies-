using System.Linq;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Genres
{
  public class EditModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Genre Genre { get; set; }

    public EditModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Genre = await _context.Genres.FirstOrDefaultAsync(m => m.Id == id);

      if (Genre == null) return NotFound();
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(Genre).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!GenreExists(Genre.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool GenreExists(int id) { return _context.Genres.Any(e => e.Id == id); }
  }
}