using Microsoft.AspNetCore.Mvc;
using PretzelPetApp.Models;
using PretzelPetApp.ValidationRules;
using FluentValidation.Results;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using FluentValidation;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace PretzelPetApp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
		CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            CustomerValidator cv = new CustomerValidator();
            ValidationResult results = cv.Validate(customer);
			if (results.IsValid)
			{
				cm.TAdd(customer);
				return RedirectToAction("Index", "Product");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
        }
    }
}
