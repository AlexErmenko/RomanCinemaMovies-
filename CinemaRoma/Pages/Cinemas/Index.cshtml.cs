using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Cinemas
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;

        public IndexModel(MovieContext context)
        {
            this.context = context;
        }

        public IList<Cinema> Cinema { get; set; }

        public async Task OnGetAsync()
        {
            Cinema = await context.Cinemas.ToListAsync();
        }
    }
}