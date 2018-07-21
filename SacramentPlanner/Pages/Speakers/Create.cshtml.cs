using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Speakers
{
    public class CreateModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentContext _context;

        public CreateModel(SacramentPlanner.Models.SacramentContext context)
        {
            _context = context;
        }

        public int SacramentPlanID { get; set; }

        public IActionResult OnGet(int sacramentPlanID)
        {
            SacramentPlanID = sacramentPlanID;
            return Page();
        }

        [BindProperty]
        public Speaker Speaker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Speaker.Add(Speaker);
            await _context.SaveChangesAsync();

            return Redirect($"/SacramentPlans/Index?id={Speaker.SacramentPlanID}");
        }
    }
}