using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Actors
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext context;

        public DeleteModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Actor = await context.Actors.FirstOrDefaultAsync(m => m.Id == id);

            if (Actor == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Actor = await context.Actors.FindAsync(id);

            if (Actor != null)
            {
                context.Actors.Remove(Actor);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}