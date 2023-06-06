using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsite.Models
{
    public class BlogPost
    {

        [Key]
        public int? BlogId { get; set; }
       
        public string? Title { get; set; }
        
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Choose the pitcure for your Blog")]
        [NotMapped]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

        //ForeignKey
        public UserLogin? Users { get; set; }

        [ForeignKey("Users")]
        public int UserLoginId { get; set; }


    }
}
