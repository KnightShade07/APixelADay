using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using APixelADay.Models;

namespace APixelADay.Views.Commissions
{
    public class CreateModel : PageModel
    {
        private readonly APixelADay.Models.PixelDBContext _context;

        public CreateModel(APixelADay.Models.PixelDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CommissionsLog CommissionsLog { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Commissions.Add(CommissionsLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
