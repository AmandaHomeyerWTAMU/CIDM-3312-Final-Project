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

        // Create property needed for sorting
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get;set;} = default!;

        public int TotalRecords {get;set;}


        public async Task OnGetAsync()
        {
            if (_context.Yarns != null)
            {
                // split original query into two parts to allow sorting with paging
                var query = _context.Yarns.Select(y => y);

                // Switch statement for each sorting option
                switch (CurrentSort)
                {
                    case "brand_asc":
                        query = query.OrderBy(y => y.Brand);
                        break;
                    case "brand_desc":
                        query = query.OrderByDescending(y => y.Brand);
                        break;
                    case "name_asc":
                        query = query.OrderBy(y => y.Name);
                        break;
                    case "name_desc":
                        query = query.OrderByDescending(y => y.Name);
                        break;
                    case "weight_asc":
                        query = query.OrderBy(y => y.Weight);
                        break;
                    case "weight_desc":
                        query = query.OrderByDescending(y => y.Weight);
                        break;
                    case "yardage_asc":
                        query = query.OrderBy(y => y.Yardage);
                        break;
                    case "yardage_desc":
                        query = query.OrderByDescending(y => y.Yardage);
                        break;
                    case "fiber_asc":
                        query = query.OrderBy(y => y.Fiber);
                        break;
                    case "fiber_desc":
                        query = query.OrderByDescending(y => y.Fiber);
                        break;
                }

                Yarn = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
                
                // Added funtionality to keep current count of all record.
                TotalRecords = await _context.Yarns.CountAsync();
            }
        }
    }
}
