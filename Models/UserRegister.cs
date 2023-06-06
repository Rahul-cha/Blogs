using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models
{
    public class UserRegister
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
        [Required]

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }



        
    }
}
