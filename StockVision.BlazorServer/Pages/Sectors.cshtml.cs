using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StockVision.Core.Models;
using StockVision.Data.Data;

namespace StockVision.BlazorServer.Pages
{
    public class SectorsModel : PageModel
    {
        private readonly StockVision.Data.Data.StockVisionContext _context;

        public SectorsModel(StockVision.Data.Data.StockVisionContext context)
        {
            _context = context;
        }

        public IList<Sector> Sector { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sectors != null)
            {
                Sector = await _context.Sectors.ToListAsync();
            }
        }
    }
}
