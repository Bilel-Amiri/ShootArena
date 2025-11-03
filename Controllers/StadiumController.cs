using Microsoft.AspNetCore.Mvc;

namespace Shoot.Controllers
{
    public class StadiumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
