using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaRoma.Models;

namespace CinemaRoma.Pages.CinemaMovies
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaRoma.Models.MovieContext _context;

        public DetailsModel(CinemaRoma.Models.MovieContext context)
        {
            _context = context;
        }

        public CinemaMovie CinemaMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinemaMovie = await _context.CinemaMovies
                .Include(c => c.Cinema)
                .Include(c => c.Movie).FirstOrDefaultAsync(m => m.MovieId == id);

            if (CinemaMovie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
