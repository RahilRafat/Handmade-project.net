using Microsoft.AspNetCore.Mvc;
using project_SWD.Data;
using project_SWD.Models;

namespace project_SWD.Controllers
{
    public class contController : Controller
    {
        private readonly ApplicationDBcontext _dbContext;

        public contController(ApplicationDBcontext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult contact()
        {
            return View(new comment());
        }
        [HttpPost]
        public IActionResult contact(comment model)
        {
            _dbContext.comments.Add(model);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

       
} 
}
