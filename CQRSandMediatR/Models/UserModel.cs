using System.ComponentModel.DataAnnotations;

namespace CQRSandMediatR.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "User name is required!")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string? Email { get; set;}

        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set;}

        [Required(ErrorMessage = "IsAdmin is required!")]
        public bool IsAdmin { get; set;} = false;
    }
}
