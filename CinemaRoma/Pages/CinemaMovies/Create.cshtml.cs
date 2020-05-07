﻿using System;
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
        private readonly CinemaRoma.Models.MovieContext _context;

        public CreateModel(CinemaRoma.Models.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "Address");
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Description");
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

            _context.CinemaMovies.Add(CinemaMovie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
