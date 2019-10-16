using System.ComponentModel.DataAnnotations;

namespace CW.TestSystem.Identity.Infrastructure.Models.UserPresentation
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email must be set")]
        [EmailAddress(ErrorMessage = "Not correct email address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}