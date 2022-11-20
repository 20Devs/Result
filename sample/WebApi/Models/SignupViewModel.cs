using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string Password { get; set; }

    }
}
