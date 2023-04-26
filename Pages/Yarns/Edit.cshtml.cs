using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YarnCatalog.Models;

namespace final_project.Pages_Yarns
{
    public class EditModel : PageModel
    {
        private readonly YarnCatalog.Models.YarnDbContext _context;

        public EditModel(YarnCatalog.Models.YarnDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Yarn Yarn { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Yarns == null)
            {
                return NotFound();
            }

            var yarn =  await _context.Yarns.FirstOrDefaultAsync(m => m.YarnId == id);
            if (yarn == null)
            {
                return NotFound();
            }
            Yarn = yarn;
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

            _context.Attach(Yarn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YarnExists(Yarn.YarnId))
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

        private bool YarnExists(int id)
        {
          return (_context.Yarns?.Any(e => e.YarnId == id)).GetValueOrDefault();
        }
    }
}
