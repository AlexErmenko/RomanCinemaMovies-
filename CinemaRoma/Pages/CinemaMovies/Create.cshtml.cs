using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaRoma.Models;

namespace CinemaRoma.Pages.CinemaMovies
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext context;

        public CreateModel(MovieContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CinemaId"] = new SelectList(context.Cinemas, "Id", "Location");
        ViewData["MovieId"] = new SelectList(context.Movies, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public CinemaMovie CinemaMovie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.CinemaMovies.Add(CinemaMovie);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
