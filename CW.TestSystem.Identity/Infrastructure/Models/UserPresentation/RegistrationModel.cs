using System.ComponentModel.DataAnnotations;

namespace CW.TestSystem.Identity.Infrastructure.Models.UserPresentation
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "User must have name")]
        [MinLength(2, ErrorMessage = "Name can not be less than 2 symbols")]
        [MaxLength(20, ErrorMessage = "Please, put your name in form, where it be less than 20 symbols")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, put your email, to be unique user and get confirm your account")]
        [EmailAddress(ErrorMessage = "Not correct email address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}