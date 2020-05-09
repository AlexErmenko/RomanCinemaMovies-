using System.Linq;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.MovieActors
{
    public class EditModel : PageModel
    {
        private readonly MovieContext context;

        public EditModel(MovieContext context)
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
            ViewData["ActorId"] = new SelectList(context.Actors, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(context.Movies, "Id", "Description");
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.Attach(MovieActor).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorExists(MovieActor.MovieId))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool MovieActorExists(int id)
        {
            return context.MovieActors.Any(e => e.MovieId == id);
        }
    }
}