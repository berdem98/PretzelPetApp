using DataAccessLayer.Concrete;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PretzelPetApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var orders = c.Orders.Select(i => new AdminOrderModel()
            {
                OrderId = i.OrderId,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count()
            }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        public IActionResult Details(int id)
        {
            var entity = c.Orders.Where(i => i.OrderId == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.OrderId,
                    FullName=i.FullName,
                    CustomerId = i.CustomerId,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    Total = i.Total,
                    OrderState = i.OrderState,
                    AdressHeader = i.AdressHeader,
                    Adress = i.Adress,
                    City = i.City,
                    District = i.District,
                    PostCode = i.PostCode,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.ProductName,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Product.Price,
                    }).ToList()

                }).FirstOrDefault();
            return View(entity);
        }
        public IActionResult UpdateOrderState(int orderId, EnumOrderState OrderState)
        {
            var entity = c.Orders.FirstOrDefault(i => i.OrderId == orderId);
            if(entity != null)
            {
                entity.OrderState = OrderState;
                c.SaveChanges();
                TempData["message"] = "Bilgileriniz Kayıt Edildi";
                return RedirectToAction("Details", new { id = orderId });
            }

            return RedirectToAction("Index");
        }
    }
}
