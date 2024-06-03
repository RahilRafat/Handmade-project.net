using Microsoft.AspNetCore.Mvc;
using project_SWD.Data;
using project_SWD.Models;
using System.Diagnostics;

namespace project_SWD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDBcontext _dbcontext;

        public HomeController(ILogger<HomeController> logger , ApplicationDBcontext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var name = HttpContext.Session.GetInt32("id");
            if (name==null)
            {
               return RedirectToAction("Register", "Account");

            }
            return View();
        }

        //public IActionResult product([FromQuery] int categoryID)
        //{
        //    ViewBag.CatName = _dbcontext.categories.Where(c => c.category_ID == categoryID).FirstOrDefault().category_name;
        //    return View(_dbcontext.products.Where(c => c.categoryID == categoryID).ToList());
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Accessories()
        {
            return View(_dbcontext.products.Where(c => c.categoryID == 1).ToList());
        }
        public IActionResult Crochet()
        {
            return View(_dbcontext.products.Where(c => c.categoryID == 2).ToList());
        }
        public IActionResult Earthenware()
        {
            return View(_dbcontext.products.Where(c => c.categoryID == 3).ToList());
        }
        public IActionResult Tapestry()
        {
            return View(_dbcontext.products.Where(c => c.categoryID == 6).ToList());
        }
        public IActionResult Macrame()
        {
            return View(_dbcontext.products.Where(c => c.categoryID == 4).ToList());
        }
    }
}