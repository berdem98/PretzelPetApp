using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        public IActionResult AddToCart(int id, int quantity) // Quantity parametresini ekleyin
        {
            var product = pm.GetById(id);
            if (product != null)
            {
                var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcının ID'sini al
                var cart = GetCart(customerId);
                cart.AddProduct(product, quantity); // Quantity'yi de parametre olarak ekleyin
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

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var cart = GetCart(customerId);
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, shippingDetails);
                //cart.Clear();
                HttpContext.Session.Clear();
                return View("Completed");
            }
            else
            {

                return View(shippingDetails);
            }

            
        }

        private void SaveOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using var c = new Context();
            var order = new Order();

            order.OrderNumber ="A"+(new Random()).Next(111111, 999999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.FullName = shippingDetails.FullName;
            order.AdressHeader = shippingDetails.AdressHeader;
            order.Adress=shippingDetails.Adress;
            order.City = shippingDetails.City;
            order.District= shippingDetails.District;
            order.PostCode = shippingDetails.PostCode;
            order.OrderLines = new List<OrderLine>();
            
            foreach (var product in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = product.Quantity;
                orderline.Price =product.Quantity*product.Product.Price;
                orderline.ProductId=product.Product.ProductId;
                
                order.OrderLines.Add(orderline);
            }
            c.Orders.Add(order);
            c.SaveChanges();
            
        }
    }

}
