using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_SWD.Data;

namespace project_SWD.Controllers
{
    public class SellerHomeController : Controller
    {
        private ApplicationDBcontext _dbcontext;

        public SellerHomeController(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult sellerhome()
        {
            var name = HttpContext.Session.GetInt32("id");
            if (name == null)
            {
                return RedirectToAction("Index", "login_Admin");

            }
            return View();
        }
        public IActionResult product([FromQuery] int categoryID)
        {
            ViewBag.CatName = _dbcontext.categories.Where(c => c.category_ID == categoryID).FirstOrDefault().category_name;
            return View(_dbcontext.products.Where(c => c.categoryID == categoryID).ToList());
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Workshop()
        {
            return View();
        }

        //public IActionResult Accessories()
        //{
        //    return View(_dbcontext.products.Where(c => c.categoryID == 1).ToList());
        //}
        //public IActionResult Crochet()
        //{
        //    return View(_dbcontext.products.Where(c => c.categoryID == 2).ToList());
        //}
        //public IActionResult Earthenware()
        //{
        //    return View(_dbcontext.products.Where(c => c.categoryID == 3).ToList());
        //}
        //public IActionResult Tapestry()
        //{
        //    return View(_dbcontext.products.Where(c => c.categoryID == 6).ToList());
        //}
        //public IActionResult Macrame()
        //{
        //    return View(_dbcontext.products.Where(c => c.categoryID == 4).ToList());
        //}

    }
}
