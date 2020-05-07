using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRoma.Pages.Actors
{
  public class CreateModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Actor Actor { get; set; }

    public CreateModel(MovieContext context) { _context = context; }

    public IActionResult OnGet() { return Page(); }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Actors.Add(Actor);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}