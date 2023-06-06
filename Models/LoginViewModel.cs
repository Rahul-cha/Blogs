using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models
{
    public class LoginViewModel
    {


        [Required]
        public string? EmailorUsername { get; set; }

 



        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
      
    }
}


//[Required]
//[Display(Name ="Username/Email")]
//public string Email { get; set; }