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
        public Review AddReview {get;set;} = default!;



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

        // THIS CODE IS CAUSING AN ERROR IN MY FOR LOOP - LINE 83 - @foreach (var y in Model.Yarn.Reviews)
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            AddReview.YarnId = id;
            
            _context.Reviews.Add(AddReview);

            _context.SaveChanges();

            Yarn = _context.Yarns.Include(y => y.Reviews).First(y => y.YarnId == id); 

            return Page();
        } 

        //THIS CODE IS CAUSING AN ERROR IN MY FOR LOOP - LINE 83 - @foreach (var y in Model.Yarn.Reviews)
        public IActionResult OnPostDeleteReview(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find review in the database
            var ReviewToDelete = _context.Reviews.FirstOrDefault(r => r.ReviewId == ReviewIdToDelete);

            if (ReviewToDelete != null)
            {
                _context.Remove(ReviewToDelete);
                _context.SaveChanges();
            }

            Yarn = _context.Yarns.Include(y => y.Reviews).First(y => y.YarnId == id);

            return Page();
        }
 
    }
}
