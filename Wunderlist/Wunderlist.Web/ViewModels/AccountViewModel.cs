using System.ComponentModel.DataAnnotations;

namespace Epam.Wunderlist.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }       

    }

    public class RegisterViewModel
    {

        [Display(Name = "Enter your e-mail*")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Display(Name = "Enter your Name*")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [Display(Name = "Password*")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

    }


}