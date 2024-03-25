using Microsoft.AspNetCore.Mvc;

namespace PretzelPetApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
