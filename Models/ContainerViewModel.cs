using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsite.Models
{
    public class ContainerViewModel
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Name { get; set; }

        public string? Gender { get; set; }
        public string? Contact_Number { get; set; }

        public string? Bio { get; set; }

        public IFormFile? ProfilePic { get; set; }
        public string? PPUrl { get; set; }



       
        public string? UserName { get; set; }

        public int? uid { get; set; }

       
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

       
        public string? Password { get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        //[Required]
        //public string? UserType { get; set; }


        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;

        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? Error { get; set; }

    }
}
