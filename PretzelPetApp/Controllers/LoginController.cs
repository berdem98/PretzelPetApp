using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PretzelPetApp.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Customer p)
		{
			Context c = new Context();
            if (ModelState.IsValid)
            {
                var isCustomer = c.Customers.FirstOrDefault(x => x.CustomerMail == p.CustomerMail && x.CustomerPassword == p.CustomerPassword);
                if (isCustomer != null)
                {
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isCustomer.CustomerId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isCustomer.CustomerName ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isCustomer.CustomerName ?? ""));
                    if (isCustomer.CustomerMail == "berk@gmail.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    var userIdendity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(userIdendity),
                        authProperties);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
                }
            }
			
            return View();

		}
        public async Task<IActionResult> Logout()
        {
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}

