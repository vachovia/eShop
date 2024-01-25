using System.ComponentModel.DataAnnotations;

namespace eShop.Web.Common.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
    }
}
