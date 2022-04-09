using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace News_Site.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
		[Required]
		[Compare("Password", ErrorMessage = "Password not  equal")]
		[DataType(DataType.Password)]
		[Display(Name = "Password Confirm")]
		public string PasswordConfirm { get; set; }
	}
}
