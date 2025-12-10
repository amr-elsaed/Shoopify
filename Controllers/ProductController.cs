using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shoopify.Data;
using Shoopify.Models.Entities;
using Shoopify.Models.Repository;

namespace Shoopify.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepo _productRepo;

        public ProductController(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(_productRepo.GetAllProduct());
        }



        //Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        //Update
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var product = _productRepo.GetById(id);
        //    if (product == null)
        //        return NotFound();

        //    return View(product);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(product);
        //    }

        //    await _productRepo.UpdateAsync(product);
        //    return RedirectToAction("Index"); 
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _productRepo.UpdateAsync(product);
            return RedirectToAction("Index");
        }


        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepo.DeleteIngredient(id);
            return RedirectToAction("Index");
        }
    }
}
