using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacramentPlanner.Models
{
    public class SacramentContext : DbContext
    {
        public SacramentContext (DbContextOptions<SacramentContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentPlan> SacramentPlan { get; set; }
        public DbSet<Speaker> Speaker { get; set; }
    }
}
