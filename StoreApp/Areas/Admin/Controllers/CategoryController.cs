using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Categories";
            return View(_manager.CategoryService.GetAllCategories(false));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _manager.CategoryService.CreateCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
			var category = _manager.CategoryService.GetOneCategory(id, false);
			if (category == null)
            {
				return NotFound();
			}

			return View(category);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Update([FromRoute(Name = "id")] int id, Category category)
        {
			if (ModelState.IsValid)
            {
				_manager.CategoryService.UpdateCategory(id);
				return RedirectToAction("Index");
			}

			return View(category);
		}

		public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
			_manager.CategoryService.DeleteCategory(id);
			return RedirectToAction("Index");
		}

    }
}