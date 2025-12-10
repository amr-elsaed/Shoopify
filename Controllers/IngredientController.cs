using Microsoft.AspNetCore.Mvc;
using Shoopify.Models.Entities;
using Shoopify.Models.Repository;

namespace Shoopify.Controllers
{
    public class IngredientController : Controller
    {
        IngredientRepo ingredientRepo = new IngredientRepo();

        public IActionResult Index()
        {
            return View(ingredientRepo.GetAllIngredient());
        }

        //Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var x = ingredientRepo.GetSpecificIngredientIncludeProduct(id);
            if (x == null)
                return NotFound();
            return View(x);
        }
        [HttpPost]
        public IActionResult Details(List<Ingredient> l)
        {
            return View();
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ingredient i)
        {
            ingredientRepo.AddIngredient(i);
            return RedirectToAction("Index");
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var x = ingredientRepo.GetById(id);
            if (x == null)
                return NotFound();
            return View(x);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        { 
            ingredientRepo.DeleteIngredient(id);
            return RedirectToAction("Index");
        }

        //Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var x = ingredientRepo.GetById(id);
            if (x == null)
                return NotFound();
            return View(x);
        }
        [HttpPost]
        public IActionResult Update(Ingredient ingredient)
        {
            ingredientRepo.UpdateIngredient(ingredient);
            return RedirectToAction("Index");
        }

    }
}
