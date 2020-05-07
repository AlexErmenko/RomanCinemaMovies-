using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Actors
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<Actor> Actor { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync() { Actor = await _context.Actors.ToListAsync(); }
  }
}