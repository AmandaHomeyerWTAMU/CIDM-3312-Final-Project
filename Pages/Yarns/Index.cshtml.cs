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
    public class IndexModel : PageModel
    {
        private readonly YarnCatalog.Models.YarnDbContext _context;

        public IndexModel(YarnCatalog.Models.YarnDbContext context)
        {
            _context = context;
        }

        public IList<Yarn> Yarn { get;set; } = default!;

        // Create properties needed for paging

        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;

        public int PageSize {get;set;} = 10;


        public async Task OnGetAsync()
        {
            if (_context.Yarns != null)
            {
                Yarn = await _context.Yarns.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            }
        }
    }
}
