using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auth.JWT.API.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
