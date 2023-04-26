using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YarnCatalog.Models;

namespace final_project.Pages_Yarns
{
    public class CreateModel : PageModel
    {
        private readonly YarnCatalog.Models.YarnDbContext _context;

        public CreateModel(YarnCatalog.Models.YarnDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Yarn Yarn { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Yarns == null || Yarn == null)
            {
                return Page();
            }

            _context.Yarns.Add(Yarn);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
