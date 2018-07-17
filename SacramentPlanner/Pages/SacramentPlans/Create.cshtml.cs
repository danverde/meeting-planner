using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.SacramentPlans
{
    public class CreateModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentContext _context;

        public CreateModel(SacramentPlanner.Models.SacramentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SacramentPlan SacramentPlan { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SacramentPlan.Add(SacramentPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}