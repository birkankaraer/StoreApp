using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
			ViewData["Title"] = "Products";
			var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrenPage = p.PageNumber,
                ItemsPerpage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }
        //endpointler manipilasyona a��kt�r �zerinde �al��malar yapabiliriz
        public IActionResult Get([FromRoute(Name = "id")] int id)//e�le�meler daha do�ru ger�ekle�sin
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewData["Title"] = model.ProductName;
            return View(model);
        }
    }
}