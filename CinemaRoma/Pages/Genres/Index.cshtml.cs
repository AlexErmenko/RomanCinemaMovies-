using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;

        public IndexModel(MovieContext context)
        {
            this.context = context;
        }

        public IList<Genre> Genre { get; set; }

        public async Task OnGetAsync()
        {
            Genre = await context.Genres.ToListAsync();
        }
    }
}