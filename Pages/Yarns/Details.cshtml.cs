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

        [BindProperty]
        public Review Review {get;set;} = default!;

        [BindProperty]
        public int ReviewIdToDelete {get;set;}

        [BindProperty]
        public int AddReview {get;set;}



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Yarns == null)
            {
                return NotFound();
            }

            var yarn = await _context.Yarns.Include(y => y.Reviews).FirstOrDefaultAsync(y => y.YarnId == id);
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

       /*  public IActionResult OnPostAddReview(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var Yarn = _context.Yarns.FirstOrDefault(y => y.YarnId == AddReview);

            _context.Reviews.Add(Review);

            // _context.Add(Review);
            _context.SaveChanges();

            Yarn = _context.Yarns.Include(y => y.Reviews).First(y => y.YarnId == id);

            return Page();
        } */

        /* public IActionResult OnPostDeleteReview(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find review in the database
            var Review = _context.Reviews.FirstOrDefault(y => y.ReviewId == ReviewIdToDelete);

            if (Review != null)
            {
                _context.Remove(Review);
                _context.SaveChanges();
            }

            Yarn = _context.Yarns.Include(y => y.Reviews).First(y => y.YarnId == id);

            return Page();
        }
 */
    }
}
