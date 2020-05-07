using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Cinemas
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<Cinema> Cinema { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync() { Cinema = await _context.Cinemas.ToListAsync(); }
  }
}