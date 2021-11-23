using Auth.JWT.API.ViewModel.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Auth.JWT.API.ViewModel
{
    public class UsuarioViewModel : BaseViewModel
    {   
        [Required]        
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
