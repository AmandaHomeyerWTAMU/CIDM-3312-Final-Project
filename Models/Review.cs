using System.ComponentModel.DataAnnotations;

namespace YarnCatalog.Models
{
    public class Review
    {
        public int ReviewId {get;set;} //primary key
        
        [Range(1,5)]
        [Required]
        public int Rating {get;set;}

        [StringLength(300)]
        [Required]
        public string Message {get;set;} = string.Empty;

        [Display(Name = "Yarn")]
        [Required]

        public int YarnId {get;set;} //foreign key
        public Yarn? Yarn {get;set;} //navigation property

    }   

}