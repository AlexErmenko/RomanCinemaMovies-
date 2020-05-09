using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.MovieActors
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext context;

        public DeleteModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public MovieActor MovieActor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            MovieActor = await context.MovieActors.Include(m => m.Actor)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (MovieActor == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            MovieActor = await context.MovieActors.FindAsync(id);

            if (MovieActor != null)
            {
                context.MovieActors.Remove(MovieActor);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}