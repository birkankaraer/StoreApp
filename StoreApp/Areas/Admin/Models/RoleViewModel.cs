using System.ComponentModel.DataAnnotations;

namespace StoreApp.Areas.Admin.Models
{
	public class RoleViewModel
	{
		[Required(ErrorMessage = "Role Name is required.")]
		public string RoleName { get; set; }
    }
}
