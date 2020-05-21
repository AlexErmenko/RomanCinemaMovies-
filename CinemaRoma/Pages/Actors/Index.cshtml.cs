using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;

        public IndexModel(MovieContext context)
        {
            this.context = context;
        }

        [BindProperty(SupportsGet = true)]
        public IList<Actor> Actor { get; set; }

        public async Task OnGetAsync()
        {
            Actor = await context.Actors.ToListAsync();
        }
    }
}