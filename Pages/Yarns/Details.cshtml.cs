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
         // Added logger for debugging
        private readonly ILogger<DetailsModel> _logger;
        private readonly YarnCatalog.Models.YarnDbContext _context;
        public DetailsModel(ILogger<DetailsModel> logger, YarnCatalog.Models.YarnDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public Yarn Yarn { get; set; } = default!; 

        [BindProperty]
        public Review Review {get;set;} = default!;

        [BindProperty]
        public int ReviewIdToDelete {get;set;}


        // Per kdana - Remove AddReview property. We will use the Review property above to add reviews
        // Every bound property must be in a valid state when you do OnPost(). Having both 'Review' and 'AddReview'
        // meant that the unused 'Review' property was empty and invaliad so OnPost() through a ModelState.IsValid error
        //[BindProperty]
        //public Review AddReview {get;set;} = default!;



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
            // kdana - Any time you run into an error put in some debugging messages to trace the problem
            // Notice I removed AddReview and we are now using 'Review'
            _logger.LogWarning($"OnPost: id = {id}, Review.YarnId = '{Review.YarnId}' Review.Rating = {Review.Rating} Message = {Review.Message}");
            
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("INSIDE INVALID");

                // kdana - This code prints out all the model state errors so you can see what property and variable is
                // causing the problem. This clued me into the Review property being empty.
                // Right now there should be no model state errors, but this code is useful for the future.

                foreach (var modelError in ModelState)
                {
                    string propertyName = modelError.Key;
                    if (modelError.Value.Errors.Count > 0)
                    {
                        _logger.LogWarning($"ERROR: {propertyName} {modelError.Value.Errors[0].ErrorMessage}");
                    }
                }
                return Page();
            }
            
            Review.YarnId = id;
            
            _context.Reviews.Add(Review);

            _context.SaveChanges();

            Yarn = _context.Yarns.Include(y => y.Reviews).First(y => y.YarnId == id); 

            return Page();
        } 

        //THIS CODE IS CAUSING AN ERROR IN MY FOR LOOP - LINE 83 - @foreach (var y in Model.Yarn.Reviews)
        public IActionResult OnPostDeleteReview(int? id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            // kdana - This error is more subtle. We are not using the 'Review' property so it should be empty.
            // But if it is empty, it will throw that ModelState error.
            // My solution is to not check for any ModelState errors and just make sure id != null.

            _logger.LogWarning($"Inside OnPostDeleteReview. ReviewIdToDelete {ReviewIdToDelete}");

            if (id == null)
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
