using System.Collections.Generic;
using System.Threading.Tasks;


using CinemaRoma.Models;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaRoma.Pages.Producers
{
  public class IndexModel : PageModel
  {
    private readonly MovieContext _context;

    public IList<Director> Director { get; set; }

    public IndexModel(MovieContext context) { _context = context; }

    public async Task OnGetAsync() { Director = await _context.Directors.ToListAsync(); }
  }
}