using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_SWD.Data;
using project_SWD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;


namespace project_SWD.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDBcontext _dbcontext;
        public AccountController(ApplicationDBcontext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(customer user)
        {
            //if (ModelState.IsValid)
            //{
                _dbcontext.customers.Add(user);
                _dbcontext.SaveChanges();
                return RedirectToAction("Login", "Account");
            //}
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(customer model)
        {
            
          //      if (ModelState.IsValid)
          //      {

                    var customer = _dbcontext.customers.FirstOrDefault(u => u.Email == model.Email);

                    if (customer != null && customer.Password == model.Password)
                    {
                    //if (ISseller.isAdmin == true)
                    //{
                    //    HttpContext.Session.SetInt32("id", ISseller.seller_ID);

                    //    return RedirectToAction("homeseller", "SellerHome");
                    //}
                    //else
                    //{
                        HttpContext.Session.SetInt32("id", customer.customer_ID);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid email or Password");
                    }
             return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("ShowCart");

            return RedirectToAction("Login");
        }

        //   } 
        //var acount = _dbcontext.customers.FirstOrDefault(u => u.Email == model.Email);
        //if (acount != null && acount.Password == model.Password)
        //{
        //    HttpContext.Session.SetInt32("id", acount.customer_ID);
        //    return RedirectToAction("Index", "Home");

        //}

        // }     


        //private customers AuthenticateUser(string email, int Password)
        //{

        //   // Retrieve user from your data store
        //   //    // Compare provided email and password with stored values
        //   //    // Return User object if authenticated, null otherwise
        //   var user = _dbcontext..FirstOrDefault(u => u.Email == email);

        //   if (user != null && user.Password == password)
        //   {
        //       return user;
        //   }
        //   return null;
        //}

    }
}
