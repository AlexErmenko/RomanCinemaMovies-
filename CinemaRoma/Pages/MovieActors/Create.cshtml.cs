using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaRoma.Pages.MovieActors
{
  public class CreateModel : PageModel
  {
    private readonly MovieContext context;

    [BindProperty]
    public MovieActor MovieActor { get; set; }

    public CreateModel(MovieContext context) { this.context = context; }

    public IActionResult OnGet()
    {
      ViewData["ActorId"] = new SelectList(context.Actors, "Id", "FullName");
      ViewData["MovieId"] = new SelectList(context.Movies, "Id", "Title");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.MovieActors.Add(MovieActor);
      await context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
