using Microsoft.AspNetCore.Mvc;

namespace CompanyContacts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "People");
            }
            return View();
        }

      
    }
}
