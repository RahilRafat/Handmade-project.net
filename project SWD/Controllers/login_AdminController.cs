using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_SWD.Data;
using project_SWD.Models;
using project_SWD.Controllers;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace project_SWD.Controllers
{
    public class login_AdminController : Controller
    {
        private readonly ApplicationDBcontext _dbcontext;
        public login_AdminController(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbcontext.sellers.Where(u => u.Email == model.Email).FirstOrDefault();
                if (user != null && user.Password == model.Password)
                {
                    HttpContext.Session.SetInt32("id",user.seller_ID);
                    return RedirectToAction("sellerhome", "SellerHome");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or Password");
                }
            }

            return View(model);
        
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}
