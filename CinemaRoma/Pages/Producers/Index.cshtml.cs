using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaRoma.Models;

namespace CinemaRoma.Pages.Producers
{
    public class IndexModel : PageModel
    {
        private readonly CinemaRoma.Models.MovieContext _context;

        public IndexModel(CinemaRoma.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Director> Director { get;set; }

        public async Task OnGetAsync()
        {
            Director = await _context.Directors.ToListAsync();
        }
    }
}
