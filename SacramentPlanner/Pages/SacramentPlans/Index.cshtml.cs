using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.SacramentPlans
{
    public class IndexModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentContext _context;

        public IndexModel(SacramentPlanner.Models.SacramentContext context)
        {
            _context = context;
        }

        public IList<SacramentPlan> SacramentPlan { get;set; }

        public async Task OnGetAsync()
        {
            SacramentPlan = await _context.SacramentPlan.ToListAsync();
        }
    }
}
