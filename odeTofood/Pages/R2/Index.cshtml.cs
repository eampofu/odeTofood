using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using odeTofood.Core;
using odeTofood.Data;

namespace odeTofood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly odeTofood.Data.odeTofoodDbContext _context;

        public IndexModel(odeTofood.Data.odeTofoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
