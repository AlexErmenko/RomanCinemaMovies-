using System.Linq;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Genres
{
    public class EditModel : PageModel
    {
        private readonly MovieContext context;

        public EditModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Genre = await context.Genres.FirstOrDefaultAsync(m => m.Id == id);

            if (Genre == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.Attach(Genre).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(Genre.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool GenreExists(int id)
        {
            return context.Genres.Any(e => e.Id == id);
        }
    }
}