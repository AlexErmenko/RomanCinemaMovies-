using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.CinemaMovies
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContext context;

        public DetailsModel(MovieContext context)
        {
            this.context = context;
        }

        public CinemaMovie CinemaMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            CinemaMovie = await context.CinemaMovies
                .Include(c => c.Cinema)
                .Include(c => c.Movie).FirstOrDefaultAsync(m => m.MovieId == id);

            if (CinemaMovie == null) return NotFound();
            return Page();
        }
    }
}