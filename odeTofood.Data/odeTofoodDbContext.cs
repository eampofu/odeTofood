using Microsoft.EntityFrameworkCore;
using odeTofood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odeTofood.Data
{
    public class odeTofoodDbContext:DbContext
    {
        public odeTofoodDbContext(DbContextOptions<odeTofoodDbContext>options):base(options) 
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
