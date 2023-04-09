using System.ComponentModel.DataAnnotations;

namespace WebApiTest.ViewModels
{
    public class SignInRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
