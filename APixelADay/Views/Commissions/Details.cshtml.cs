using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APixelADay.Models;

namespace APixelADay.Views.Commissions
{
    public class DetailsModel : PageModel
    {
        private readonly APixelADay.Models.PixelDBContext _context;

        public DetailsModel(APixelADay.Models.PixelDBContext context)
        {
            _context = context;
        }

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
    }
}
