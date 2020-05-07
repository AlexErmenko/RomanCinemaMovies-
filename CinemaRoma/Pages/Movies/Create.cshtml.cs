using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaRoma.Pages.Movies
{
  public class CreateModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Movie Movie { get; set; }

    public CreateModel(MovieContext context) { _context = context; }

    public IActionResult OnGet()
    {
      ViewData["GenreId"]    = new SelectList(_context.Genres, "Id", "Id");
      ViewData["ProducerId"] = new SelectList(_context.Directors, "Id", "FirstName");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Movies.Add(Movie);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}