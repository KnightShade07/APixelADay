using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APixelADay.Models;

namespace APixelADay.Views.Commissions
{
    public class EditModel : PageModel
    {
        private readonly APixelADay.Models.PixelDBContext _context;

        public EditModel(APixelADay.Models.PixelDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CommissionsLog CommissionsLog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CommissionsLog = await _context.Commissions.FirstOrDefaultAsync(m => m.ComissionID == id);

            if (CommissionsLog == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CommissionsLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommissionsLogExists(CommissionsLog.ComissionID))
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

        private bool CommissionsLogExists(int id)
        {
            return _context.Commissions.Any(e => e.ComissionID == id);
        }
    }
}
