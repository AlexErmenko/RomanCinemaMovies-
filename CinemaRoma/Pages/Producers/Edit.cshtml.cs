using System.Linq;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Producers
{
    public class EditModel : PageModel
    {
        private readonly MovieContext context;

        public EditModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public Director Director { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Director = await context.Directors.FirstOrDefaultAsync(m => m.Id == id);

            if (Director == null) return NotFound();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.Attach(Director).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(Director.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool DirectorExists(int id)
        {
            return context.Directors.Any(e => e.Id == id);
        }
    }
}