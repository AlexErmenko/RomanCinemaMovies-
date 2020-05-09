using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaRoma.Pages.CinemaMovies
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext context;

        public CreateModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public CinemaMovie CinemaMovie { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Cinema"] = new SelectList(context.Cinemas, "Id", "Location");
            ViewData["Movie"] = new SelectList(context.Movies, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.CinemaMovies.Add(CinemaMovie);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}