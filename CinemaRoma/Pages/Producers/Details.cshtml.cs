using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Producers
{
    public class DetailsModel : PageModel
    {
        private readonly MovieContext context;

        public DetailsModel(MovieContext context)
        {
            this.context = context;
        }

        public Director Director { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Director = await context.Directors.FirstOrDefaultAsync(m => m.Id == id);

            if (Director == null) return NotFound();
            return Page();
        }
    }
}