using Microsoft.AspNetCore.Mvc;

namespace project_SWD.Controllers
{
    public class HomeStaticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Accessories()
        {
            return View();
        }
        public IActionResult Crochet()
        {
            return View();
        }
        public IActionResult Earthenware()
        {
            return View();
        }
        public IActionResult Tapestry()
        {
            return View();
        }
        public IActionResult Macrame()
        {
            return View();
        }
    }
}
