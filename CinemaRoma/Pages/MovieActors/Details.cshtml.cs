using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaRoma.Models;

namespace CinemaRoma.Pages.MovieActors
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaRoma.Models.MovieContext _context;

        public DetailsModel(CinemaRoma.Models.MovieContext context)
        {
            _context = context;
        }

        public MovieActor MovieActor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieActor = await _context.MovieActors
                .Include(m => m.Actor)
                .Include(m => m.Movie).FirstOrDefaultAsync(m => m.MovieId == id);

            if (MovieActor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
