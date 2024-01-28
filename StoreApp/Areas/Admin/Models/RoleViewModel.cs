using System.ComponentModel.DataAnnotations;

namespace StoreApp.Areas.Admin.Models
{
	public class RoleViewModel
	{
        public string RoleId { get; set; }
		[Required(ErrorMessage = "Role Name is required.")]
		public string RoleName { get; set; }
    }
}
