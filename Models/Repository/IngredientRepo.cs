using Microsoft.EntityFrameworkCore;
using Shoopify.Data;
using Shoopify.Models.Entities;

namespace Shoopify.Models.Repository
{

    public class IngredientRepo
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
     

        public ICollection<Ingredient> GetAllIngredient()
        {
            return _context.Ingredients.ToList();
        }
        public void AddIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }
        public Ingredient? GetById(int id)
        {
            return _context.Ingredients.Find(id);
        }
        public void UpdateIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
        }
        public void DeleteIngredient(int id)
        {
            var x = _context.Ingredients.Find(id);
            if (x != null)
            {
                {
                    _context.Ingredients.Remove(x);
                    _context.SaveChanges();
                }
            }

        }

        public List<Ingredient> GetAllIngredientIncludeProduct()
        {
            return _context.Ingredients.Include(i => i.ProductIngredients).ThenInclude(pi => pi.Product).ToList();
        }
        
        public List<Ingredient> GetSpecificIngredientIncludeProduct(int id)
        {
            return _context.Ingredients.Include(i => i.ProductIngredients).ThenInclude(pi => pi.Product).Where(x=>x.IngredientId == id).ToList();
        }


    }
}
