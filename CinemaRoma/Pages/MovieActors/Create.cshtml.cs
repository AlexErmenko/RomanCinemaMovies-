using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaRoma.Pages.MovieActors
{
  public class CreateModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public MovieActor MovieActor { get; set; }

    public CreateModel(MovieContext context) { _context = context; }

    public IActionResult OnGet()
    {
      ViewData["ActorId"] = new SelectList(_context.Actors, "Id", "FirstName");
      ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.MovieActors.Add(MovieActor);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}