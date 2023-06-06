using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsite.Models
{
    public class UserDetails
    {

        [Key]
        public int? UId { get; set; }


        
        public string? Name { get; set; }

       
        public string? ContactNumber { get; set; }

        
        public string? Gender { get; set; }

        public string? ProfileBio { get; set; }


        [NotMapped]
        public IFormFile? ProfilePic { get; set; }

        public string? ProfilePicUrl { get; set; }


        //[Display(Name = "Choose profile picture")]
        //[NotMapped]
        //public IFormFile? ProfilePic { get; set; }

        //public string? PicUrl { get; set; }


        //Foreign Key
        public UserLogin? Login { get; set; }
        [ForeignKey("Login")]
        public int? LoginId { get; set; }



    }
}
