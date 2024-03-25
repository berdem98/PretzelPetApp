using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PretzelPetApp.Controllers
{
    public class AdminController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var products = pm.GetList();
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
