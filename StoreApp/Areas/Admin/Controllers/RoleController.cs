using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Areas.Admin.Models;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class RoleController : Controller
	{
		private readonly IServiceManager _manager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public RoleController(IServiceManager manager, RoleManager<IdentityRole> roleManager)
		{
			_manager = manager;
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			ViewData["Title"] = "Roles";
			return View(_manager.AuthService.Roles);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(RoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				var role = new IdentityRole { Name = model.RoleName };
				var result = await _roleManager.CreateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction(nameof(Index));
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

	}
}
