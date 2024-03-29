﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PretzelPetApp.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult Index(int id)
        {
            var products = pm.GetProductListWithCategory(id);
            return View(products);
        }
        public IActionResult Groom()
        {
            return View();
        }
    }

}
