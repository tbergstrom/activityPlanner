using System.ComponentModel.DataAnnotations;
namespace beltPlate.Models
{
        public class RegisterViewModel
        {
                [Required]
                [Display(Name = "First Name")]
                [MinLength(2, ErrorMessage="First name must be at least 2 characters!")]
                public string firstName { get; set; }

                [Required]
                [Display(Name = "Last Name")]
                [MinLength(2)]
                public string lastName { get; set; }

                [Required]
                [Display(Name = "Email Address")]
                [EmailAddress]
                public string email { get; set; }

                [Required]
                [Display(Name = "Password")]
                [MinLength(8)]
                [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be at least 8 characters, contain at least 1 letter, 1 number, and 1 special character.")]
                [DataType(DataType.Password)]
                public string password { get; set; }

                [Compare("password", ErrorMessage = "Password and confirmation do not match.")]
                [DataType(DataType.Password)]
                public string confirmPassword { get; set; }
        }
}