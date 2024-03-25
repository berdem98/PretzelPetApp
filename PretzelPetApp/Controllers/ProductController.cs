using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PretzelPetApp.Models;
using System.Runtime.Intrinsics.X86;

namespace PretzelPetApp.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        

        public IActionResult Index()
        {
            var products = pm.GetList();
            return View(products);
        }
        
        public IActionResult Details(int id)
        {
            var product = pm.GetProductById(id);
            return View(product);
        }   
        
        
    }
}
