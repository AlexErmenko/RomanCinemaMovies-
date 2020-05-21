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
        private readonly MovieContext context;

        public EditModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public CinemaMovie CinemaMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            CinemaMovie = await context.CinemaMovies
                .Include(c => c.Cinema)
                .Include(c => c.Movie).FirstOrDefaultAsync(m => m.MovieId == id);

            if (CinemaMovie == null) return NotFound();

            ViewData["CinemaId"] = new SelectList(context.Cinemas, "Id", "Location");
            ViewData["MovieId"] = new SelectList(context.Movies, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.Attach(CinemaMovie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinemaMovieExists(CinemaMovie.MovieId))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool CinemaMovieExists(int id)
        {
            return context.CinemaMovies.Any(e => e.MovieId == id);
        }
    }
}