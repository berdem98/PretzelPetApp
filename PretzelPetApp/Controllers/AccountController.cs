using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PretzelPetApp.Controllers
{
    public class AccountController : Controller
    {
        private Context c = new Context(); 
        public IActionResult Index()
        {
            var customerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orders = c.Orders.Where(i => i.CustomerId == customerId)
                .Select(i => new CustomerOrderModel()
                {
                    OrderId = i.OrderId,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    Total = i.Total,
                    OrderState = i.OrderState
                }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        public IActionResult Details(int id)
        {
            var entity = c.Orders.Where(i=>i.OrderId == id)
                .Select(i=>new OrderDetailsModel()
                {
                    OrderId=i.OrderId,
                    OrderNumber=i.OrderNumber,
                    OrderDate=i.OrderDate,
                    Total = i.Total,
                    OrderState = i.OrderState,
                    AdressHeader = i.AdressHeader,
                    Adress = i.Adress,
                    City = i.City,
                    District = i.District,
                    PostCode = i.PostCode,
                    OrderLines = i.OrderLines.Select(a=>new OrderLineModel()
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
    }
}
