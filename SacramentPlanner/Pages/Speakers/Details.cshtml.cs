using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Speakers
{
    public class DetailsModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentContext _context;

        public DetailsModel(SacramentPlanner.Models.SacramentContext context)
        {
            _context = context;
        }

        public Speaker Speaker { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Speaker = await _context.Speaker.FirstOrDefaultAsync(m => m.SpeakerID == id);

            if (Speaker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
