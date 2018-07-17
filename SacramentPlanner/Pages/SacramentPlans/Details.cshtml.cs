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
    public class DetailsModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentContext _context;

        public DetailsModel(SacramentPlanner.Models.SacramentContext context)
        {
            _context = context;
        }

        public SacramentPlan SacramentPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SacramentPlan = await _context.SacramentPlan.FirstOrDefaultAsync(m => m.SacramentPlanID == id);

            if (SacramentPlan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
