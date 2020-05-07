﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaRoma.Models;

namespace CinemaRoma.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CinemaRoma.Models.MovieContext _context;

        public IndexModel(CinemaRoma.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies
                .Include(m => m.Genre)
                .Include(m => m.Producer).ToListAsync();
        }
    }
}
