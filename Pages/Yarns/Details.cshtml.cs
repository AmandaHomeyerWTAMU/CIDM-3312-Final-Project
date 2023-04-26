using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YarnCatalog.Models;

namespace final_project.Pages_Yarns
{
    public class DetailsModel : PageModel
    {
        private readonly YarnCatalog.Models.YarnDbContext _context;

        public DetailsModel(YarnCatalog.Models.YarnDbContext context)
        {
            _context = context;
        }

      public Yarn Yarn { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Yarns == null)
            {
                return NotFound();
            }

            var yarn = await _context.Yarns.FirstOrDefaultAsync(m => m.YarnId == id);
            if (yarn == null)
            {
                return NotFound();
            }
            else 
            {
                Yarn = yarn;
            }
            return Page();
        }
    }
}
