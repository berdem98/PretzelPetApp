using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PretzelPetApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(string productName, int? categoryId)
        {
            var products = pm.GetList();
            if (categoryId.HasValue && categoryId != 0)
            {
                products = products.Where(p => p.CategoryId == categoryId).ToList();
            }
            if (!string.IsNullOrEmpty(productName))
            {
                var searchTerm = productName.ToLower();
                products = products.Where(p=>p.ProductName!.ToLower().Contains(searchTerm)).ToList();  
            }
            ViewBag.Categories = cm.GetList();
            return View(products);
        }
        public IActionResult Add()
        {

            var categories = cm.GetList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();

        }
        [HttpPost]
        public IActionResult Add(Product product)
        {

            pm.TAdd(product);
            return RedirectToAction("Index", "Admin");

        }
        public IActionResult Update(int id)
        {
            var categories = cm.GetList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            var product = pm.GetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            
            pm.TUpdate(product);
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Delete(int id)
        {  
            var product = pm.GetById(id); 
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            pm.TDelete(product);
            return RedirectToAction("Index", "Admin");
        }
    }
}
