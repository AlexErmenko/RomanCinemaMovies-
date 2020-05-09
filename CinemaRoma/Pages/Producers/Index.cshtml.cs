using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaRoma.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Producers
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;

        public IndexModel(MovieContext context)
        {
            this.context = context;
        }

        public IList<Director> Director { get; set; }

        public async Task OnGetAsync()
        {
            Director = await context.Directors.ToListAsync();
        }
    }
}