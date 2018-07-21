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

        public IList<SacramentPlan> SacramentPlan { get;set; } // this might have to be a IEnumerable
        public IEnumerable<Speaker> Speakers { get; set; }
        public int SacramentPlanID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            SacramentPlan = await _context.SacramentPlan.ToListAsync();

            if (id != null)
            {
                SacramentPlanID = id.Value;

                Speakers = _context.Speaker.Where(x => x.SacramentPlanID == SacramentPlanID);
            }
        }
    }
}
