using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
		public Cart Cart { get; set; }

		public CartModel(IServiceManager manager, Cart cart)
		{
			_manager = manager;
			Cart = cart;
		}

        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId,false);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl });
        }
		//one by one reducing method
        public IActionResult OnPostReduce(int productId, string returnUrl)
        {
			Product? product = _manager.ProductService.GetOneProduct(productId,false);
			if (product is not null)
            {
				Cart.AddItem(product, -1);
			}
			return RedirectToPage(new { returnUrl });
		}
		public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Cart.RemoveItem(Cart.Lines.First(cl => cl.Product.ProductId.Equals(productId)).Product);
            return RedirectToPage(new { returnUrl });
        }

    }
}
