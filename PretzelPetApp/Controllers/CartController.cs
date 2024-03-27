using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;


namespace PretzelPetApp.Controllers
{
    public class CartController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());

        public IActionResult Index()
        {
            var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcının ID'sini al
            var cart = GetCart(customerId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = pm.GetById(id);
            if (product != null)
            {
                var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcının ID'sini al
                var cart = GetCart(customerId);
                cart.AddProduct(product, 1);
                SaveOrUpdateCart(cart, customerId); // Sepeti kaydet veya güncelle
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var product = pm.GetById(id);
            if (product != null)
            {
                var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcının ID'sini al
                var cart = GetCart(customerId);
                cart.DeleteProduct(product);
                SaveOrUpdateCart(cart, customerId); // Sepeti kaydet veya güncelle
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult Summary()
        {
            var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcının ID'sini al
            var cart = GetCart(customerId);
            return PartialView(cart);
        }

        private Cart GetCart(int customerId)
        {
            var cartData = HttpContext.Session.GetString($"Cart_{customerId}"); // Kullanıcıya özgü sepet verilerini al
            Cart cart;

            if (cartData == null)
            {
                cart = new Cart();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartData);
            }

            return cart;
        }

        private void SaveOrUpdateCart(Cart cart, int customerId)
        {
            HttpContext.Session.SetString($"Cart_{customerId}", JsonConvert.SerializeObject(cart)); // Kullanıcıya özgü sepet verilerini sakla
        }




    }
    
}
