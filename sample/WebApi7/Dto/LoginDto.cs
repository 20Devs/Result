using System.ComponentModel.DataAnnotations;

namespace WebApi7.Dto
{
	public class LoginDto
	{
		[Required(ErrorMessage = "required")]
		public string UserName { get; set; }
	}
}
