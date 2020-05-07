﻿using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Producers
{
  public class DeleteModel : PageModel
  {
    private readonly MovieContext _context;

    [BindProperty]
    public Director Director { get; set; }

    public DeleteModel(MovieContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Director = await _context.Directors.FirstOrDefaultAsync(m => m.Id == id);

      if (Director == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Director = await _context.Directors.FindAsync(id);

      if (Director != null)
      {
        _context.Directors.Remove(Director);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}