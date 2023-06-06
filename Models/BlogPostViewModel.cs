using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsite.Models
{
    public class BlogPostViewModel
    {

        
        public int? PostId { get; set; }
        
        public string? Name { get; set; }
        public string? PostTitle { get; set; }
        
        public string? PostDescription { get; set; }
      

        public DateTime? CreatedDate { get; set; }



        public string? ImageUrl { get; set; }

        [Display(Name = "Choose the picture for your blog")]
        public IFormFile? BlogImage { get; set; }
    }
}
