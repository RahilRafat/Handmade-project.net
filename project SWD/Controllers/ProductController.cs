using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using project_SWD.Data;
using project_SWD.Models;

namespace project_SWD.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDBcontext _dbcontext;
        public ProductController(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show()
        {
            List<product> products = _dbcontext.products.ToList();
            return View(products);
        } 
        public IActionResult Cart(int id)
        {
            List<order_item> orders = HttpContext.Session.Get<List<order_item>>("cart")??new List<order_item>();
            order_item item1 = orders.FirstOrDefault(i=>i.product_ID1 == id);
            if(item1 != null)
            {
              
            }
            else
            {
                product c1 = _dbcontext.products.FirstOrDefault(i => i.product_ID == id);
                order_item newItem = new order_item
                {
                    product_ID1 = c1.product_ID,
                    product_price = c1.product_price,
                };
                orders.Add(newItem);
            }
            HttpContext.Session.Set("cart", orders);
            return RedirectToAction("ShowCart", "Product");
        }
        public IActionResult ShowCart()
        {
            List<order_item> orders = HttpContext.Session.Get<List<order_item>>("cart")??new List<order_item>();
           
            return View(orders);
        }  
        public IActionResult RemoveFromCart(int id)
        {
            List<order_item> orders = HttpContext.Session.Get<List<order_item>>("cart")??new List<order_item>();
            order_item CItem = orders.Find(i => i.product_ID1 == id);
            orders.Remove(CItem);
            HttpContext.Session.Set("cart", orders);
            return RedirectToAction("ShowCart");
        }
      
    }
}
