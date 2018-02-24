using System.ComponentModel.DataAnnotations;
namespace beltPlate.Models
{
        public class LoginViewModel
        {
                [Required(ErrorMessage = "Email address cannot be left blank")]
		public string logEmail { get; set; }
		[Required(ErrorMessage = "Incorrect password/ email combination")]
                [DataType(DataType.Password)]
		public string logPassword { get; set; }
        }
}