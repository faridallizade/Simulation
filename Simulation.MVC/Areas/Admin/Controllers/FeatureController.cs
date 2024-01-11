using Microsoft.AspNetCore.Mvc;

namespace Simulation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
