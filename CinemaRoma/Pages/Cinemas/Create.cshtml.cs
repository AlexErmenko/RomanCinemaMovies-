using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaRoma.Pages.Cinemas
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext context;

        public CreateModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Cinema Cinema { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            context.Cinemas.Add(Cinema);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}