﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Pages.Speakers
{
    public class EditModel : PageModel
    {
        private readonly SacramentPlanner.Models.SacramentContext _context;

        public EditModel(SacramentPlanner.Models.SacramentContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Speaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(Speaker.SpeakerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.SpeakerID == id);
        }
    }
}
