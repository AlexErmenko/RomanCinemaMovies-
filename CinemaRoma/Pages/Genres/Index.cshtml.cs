using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Genres
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<Genre> Genre { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync() { Genre = await _context.Genres.ToListAsync(); }
  }
}