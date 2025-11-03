using Microsoft.AspNetCore.Mvc;

namespace Shoot.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
