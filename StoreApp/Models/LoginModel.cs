using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
	public class LoginModel
	{
		private string? _returnUrl;

		[Required(ErrorMessage = "Please enter your name")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Please enter your password")]
		public string? Password { get; set; }
		public string ReturnUrl
		{
			get
			{
				if (_returnUrl == null || _returnUrl.Length == 0)
				{
					return "/";
				}
				else
				{
					return _returnUrl;
				}
			}
			set
			{
				_returnUrl = value;
			}
		}
	}
}
