using System.ComponentModel.DataAnnotations;

namespace NetPress.Areas.Account.ViewModels.Identity
{
    public class LoginViewModel
    {
        public string? ReturnUrl { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
