using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRoma.Pages.Genres
{
  public class CreateModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Genre Genre { get; set; }

    public CreateModel(MovieContext context) { _context = context; }

    public IActionResult OnGet() { return Page(); }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Genres.Add(Genre);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}