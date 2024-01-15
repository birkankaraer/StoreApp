using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

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
            var model = _manager.ProductService.GetAllProductsWithDetails(p);
            return View(model);
        }
        //endpointler manipilasyona a��kt�r �zerinde �al��malar yapabiliriz
        public IActionResult Get([FromRoute(Name = "id")] int id)//e�le�meler daha do�ru ger�ekle�sin
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}