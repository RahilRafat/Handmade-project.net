using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using project_SWD.Data;
using project_SWD.Models;


namespace project_SWD.Controllers
{
    public class categoriesController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IWebHostEnvironment _environment;
        
        

        public categoriesController(ApplicationDBcontext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: categories
        public async Task<IActionResult> Index()
        {
              return _context.categories != null ? 
                          View(await _context.categories.ToListAsync()) :
                     Problem("Entity set 'ApplicationDBcontext.categories'  is null.");
        }

        // GET: categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories
                .FirstOrDefaultAsync(m => m.category_ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("category_name,category_type")] category category ,IFormFile img_file)
        {
            string path = Path.Combine(_environment.WebRootPath, "img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
          

            if (img_file != null)
            {
               
               
                path = Path.Combine(path, img_file.FileName);// for exmple : /Img/Photoname.png
              
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    //ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
    
           
                    category.category_Pic = img_file.FileName;
            
                
                }
                

            }
            else
            {
                category.category_Pic = "default.jpg"; // to save the default image path in database.
            }
            try
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }


            return View();
        }

        // GET: categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("category_ID,category_name,category_type,category_Pic")] category category)
        {
            if (id != category.category_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoryExists(category.category_ID))
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
            return View(category);
        }

        // GET: categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categories == null)
            {
                return NotFound();
            }

            var category = await _context.categories
                .FirstOrDefaultAsync(m => m.category_ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categories == null)
            {
                return Problem("Entity set 'ApplicationDBcontext.categories'  is null.");
            }
            var category = await _context.categories.FindAsync(id);
            if (category != null)
            {
                _context.categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categoryExists(int id)
        {
          return (_context.categories?.Any(e => e.category_ID == id)).GetValueOrDefault();
        }
    }
}
