using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.CinemaMovies
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext context;

        public DeleteModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public CinemaMovie CinemaMovie { get; set; }


        public async Task<IActionResult> OnGetAsync(int idCinema, int idMovie)
        {
            /*if (id == null)
            {
                return NotFound();
            }
*/
            CinemaMovie = await context.CinemaMovies
                .Include(c => c.Cinema)
                .Include(c => c.Movie).FirstOrDefaultAsync(m => m.MovieId == idMovie && m.CinemaId == idCinema);

            if (CinemaMovie == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            CinemaMovie = await context.CinemaMovies.SingleOrDefaultAsync(it => it.CinemaId == CinemaMovie.CinemaId &&
                                                                                it.MovieId == CinemaMovie.MovieId);

            if (CinemaMovie != null)
            {
                context.CinemaMovies.Remove(CinemaMovie);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}