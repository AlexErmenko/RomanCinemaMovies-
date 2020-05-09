using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Cinemas
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext context;

        public DeleteModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty] public Cinema Cinema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Cinema = await context.Cinemas.FirstOrDefaultAsync(m => m.Id == id);

            if (Cinema == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Cinema = await context.Cinemas.FindAsync(id);

            if (Cinema != null)
            {
                context.Cinemas.Remove(Cinema);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}