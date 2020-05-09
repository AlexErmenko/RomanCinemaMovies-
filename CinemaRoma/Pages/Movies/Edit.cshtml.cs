using System.Linq;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MovieContext context;

        public EditModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Movie = await context.Movies
                .Include(m => m.Genre)
                .Include(m => m.Producer).FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null) return NotFound();
            ViewData["GenreId"] = new SelectList(context.Genres, "Id", "Name");
            ViewData["ProducerId"] = new SelectList(context.Directors, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return context.Movies.Any(e => e.Id == id);
        }
    }
}