using Microsoft.AspNetCore.Mvc;

namespace project_SWD.Controllers
{
    public class workshopsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
