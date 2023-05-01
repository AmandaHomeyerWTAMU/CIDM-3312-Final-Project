using System.ComponentModel.DataAnnotations;

namespace YarnCatalog.Models
{
    public class Yarn
    {
        public int YarnId {get;set;} //primary key

       [Required]
       [StringLength(30)]
        public string Brand {get;set;} = string.Empty;

        [Required]
        [StringLength(30)]
        public string Name {get;set;} = string.Empty;

        [Required]
        [StringLength(15)]
        public string Weight {get;set;} = string.Empty;

        [Required]
        [Range(1,1000)]
        public int Yardage {get;set;}

        [Required]
        [StringLength(30)]
        public string Fiber {get;set;} = string.Empty;

        public List<Review> Reviews {get;set;} = new List<Review>(); // navigation property
    }
}