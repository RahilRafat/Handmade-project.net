using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using project_SWD.Data;
using project_SWD.Models;

namespace project_SWD.Controllers
{
    public class prodController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IWebHostEnvironment _environment ;

        public prodController(ApplicationDBcontext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: prod
        public async Task<IActionResult> Index()
        {
            var applicationDBcontext = _context.products.Include(p => p.category).Include(p => p.seller);
            return View(await applicationDBcontext.ToListAsync());
        }

        // GET: prod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.category)
                .Include(p => p.seller)
                .FirstOrDefaultAsync(m => m.product_ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: prod/Create
        public IActionResult Create()
        {
            ViewData["categoryID"] = new SelectList(_context.categories, "category_ID", "category_name");
            ViewData["sellerID"] = new SelectList(_context.sellers, "seller_ID", "ConfirmPassword");
            return View();
        }

        // POST: prod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_ID,product_code,product_price,img,categoryID,sellerID")] product product,IFormFile img_file)
        {
            string path = Path.Combine(_environment.WebRootPath, "img");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if(img_file!=null)
            {
                path = Path.Combine(path, img_file.Name);
                using (var stream = new FileStream(path, FileMode.Create)) 
                {
                    await img_file.CopyToAsync (stream);
                    product.img = img_file.FileName;
                }
            }
            else
            {
                product.img = "1.jpg";
            }
            
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
               //return RedirectToAction("","Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            ViewData["categoryID"] = new SelectList(_context.categories, "category_ID", "category_name", product.categoryID);
            ViewData["sellerID"] = new SelectList(_context.sellers, "seller_ID", "ConfirmPassword", product.sellerID);
            //return View(product);
            return View();
        }

        // GET: prod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["categoryID"] = new SelectList(_context.categories, "category_ID", "category_name", product.categoryID);
            ViewData["sellerID"] = new SelectList(_context.sellers, "seller_ID", "ConfirmPassword", product.sellerID);
            return View(product);
        }

        // POST: prod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_ID,product_code,product_price,img,categoryID,sellerID")] product product)
        {
            if (id != product.product_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productExists(product.product_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryID"] = new SelectList(_context.categories, "category_ID", "category_name", product.categoryID);
            ViewData["sellerID"] = new SelectList(_context.sellers, "seller_ID", "ConfirmPassword", product.sellerID);
            return View(product);
        }

        // GET: prod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .Include(p => p.category)
                .Include(p => p.seller)
                .FirstOrDefaultAsync(m => m.product_ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'ApplicationDBcontext.products'  is null.");
            }
            var product = await _context.products.FindAsync(id);
            if (product != null)
            {
                _context.products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool productExists(int id)
        {
          return (_context.products?.Any(e => e.product_ID == id)).GetValueOrDefault();
        }
    }
}
