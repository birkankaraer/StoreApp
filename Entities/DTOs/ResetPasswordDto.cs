using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public record ResetPasswordDto
	{
		
		public String? UserName { get; set; }
		
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password is required.")]
		public String? Password { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "ConfirmPassword is required.")]
		[Compare("Password", ErrorMessage = "The password and confirmpassword do not match.")]
		public String? ConfirmPassword { get; set; }
    }
}
