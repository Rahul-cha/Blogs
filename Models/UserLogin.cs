using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models
{
    public class UserLogin
    {

        [Key]
        public int Id { get; set; }
        [Required]


        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        
        public List<BlogPost>? Blogs { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
