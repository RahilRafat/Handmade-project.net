using System.ComponentModel.DataAnnotations;

namespace project_SWD.Models
{
    public class Login
    {
        [Required(ErrorMessage = "please enter a vaild Email ")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        //public bool? isAdmin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
