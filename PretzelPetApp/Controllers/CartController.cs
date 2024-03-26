using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;


namespace PretzelPetApp.Controllers
{
    public class CartController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());

        public IActionResult Index()
        {
            return View(GetCart());
        }
        
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = pm.GetById(id);
            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, 1);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var product = pm.GetById(id);
            if (product != null)
            {
                var cart = GetCart();
                cart.DeleteProduct(product);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cartData = HttpContext.Session.GetString("Cart");
            Cart cart;

            if (cartData == null)
            {
                cart = new Cart();
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartData);
            }

            return cart;
        }

    }
    
}
