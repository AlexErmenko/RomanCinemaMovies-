using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.CinemaMovies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;

        public IndexModel(MovieContext context)
        {
            this.context = context;
        }

        public IList<CinemaMovie> CinemaMovie { get; set; }

        public async Task OnGetAsync()
        {
            CinemaMovie = await context.CinemaMovies
                .Include(c => c.Cinema)
                .Include(c => c.Movie).ToListAsync();
        }
    }
}