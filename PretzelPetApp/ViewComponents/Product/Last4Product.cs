using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;


namespace PretzelPetApp.ViewComponents.Product
{
    public class Last4Product : ViewComponent
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IViewComponentResult Invoke()
        {
            var values = pm.GetLast4Product();
            return View(values);
        }
    }
}
