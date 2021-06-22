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
    public class IndexModel : PageModel
    {
        private readonly APixelADay.Models.PixelDBContext _context;

        public IndexModel(APixelADay.Models.PixelDBContext context)
        {
            _context = context;
        }

        public IList<CommissionsLog> CommissionsLog { get;set; }

        public async Task OnGetAsync()
        {
            CommissionsLog = await _context.Commissions.ToListAsync();
        }
    }
}
