using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContext context;

        public DetailsModel(MovieContext context)
        {
            this.context = context;
        }

        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Genre = await context.Genres.FirstOrDefaultAsync(m => m.Id == id);

            if (Genre == null) return NotFound();
            return Page();
        }
    }
}