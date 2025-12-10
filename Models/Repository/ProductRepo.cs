using Microsoft.EntityFrameworkCore;
using Shoopify.Data;
using Shoopify.Models.Entities;
using Microsoft.AspNetCore.Hosting;


namespace Shoopify.Models.Repository
{
    public class ProductRepo
    {

        private readonly ApplicationDbContext context1 = new ApplicationDbContext();

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepo(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

    

        public ICollection<Product> GetAllProduct()
        {
            return context1.products.ToList();
        }
        public void AddProduct(Product product)
        {
            context1.products.Add(product);
            context1.SaveChanges();
        }
        public void UpdateIngredient(Product product)
        {
            context1.products.Update(product);
            context1.SaveChanges();
        }
        public void DeleteIngredient(int id)
        {
            var x = context1.products.Find(id);
            if (x != null)
            {
                {
                    context1.products.Remove(x);
                    context1.SaveChanges();
                }
            }

        }

        public List<Product> GetAllProductIncludeOrder()
        {
            return context1.products
                .Include(p => p.OrderItems)
                .ThenInclude(o => o.Order)
                .ToList();
        }

        public Product? GetSpecificProductIncludeOrder(int id)
        {
            return context1.products
                .Include(p => p.OrderItems)
                .ThenInclude(o => o.Order)
                .FirstOrDefault(p => p.ProductId == id);
        }



        public List<Product> GetAll()
        {
            return context1.products.Include(p => p.Category).ToList();
        }

        public Product? GetById(int id)
        {
            return context1.products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
        }

        public async Task AddAsync(Product product)
        {
            if (product.ImageFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                product.ImageUrl = "/Images/" + fileName;
            }

            context1.products.Add(product);
            await context1.SaveChangesAsync();
        }
        //public async Task UpdateAsync(Product product)
        //{
        //    if (product.ImageFile != null)
        //    {
        //        string wwwRootPath = _webHostEnvironment.WebRootPath;
        //        string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
        //        string extension = Path.GetExtension(product.ImageFile.FileName);

        //        fileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
        //        string path = Path.Combine(wwwRootPath + "/Images/", fileName);

        //        using (var fileStream = new FileStream(path, FileMode.Create))
        //        {
        //            await product.ImageFile.CopyToAsync(fileStream);
        //        }

        //        product.ImageUrl = "/Images/" + fileName;
        //    }

        //    context1.products.Update(product);
        //    await context1.SaveChangesAsync();
        //}
        //public async Task DeleteAsync(int id)
        //{
        //    var product = await context1.products.FindAsync(id);
        //    if (product != null)
        //    {
        //        context1.products.Remove(product);
        //        await context1.SaveChangesAsync();
        //    }
        //}

        public async Task UpdateAsync(Product product)
        {
            // جلب المنتج الأصلي
            var existingProduct = context1.products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product not found");

            // تحديث الحقول
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            // تحديث الصورة إذا تم رفع صورة جديدة
            if (product.ImageFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                existingProduct.ImageUrl = "/Images/" + fileName;
            }

            await context1.SaveChangesAsync();
        }



    }
}
