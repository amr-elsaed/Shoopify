using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoopify.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public int CategoryId { get; set; }
        [ValidateNever] //ليه علاقه بالفرونت ايند عند عمل post
        public Category? Category { get; set; }
        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }
        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; }
        
        
        [NotMapped] //مش هيتعملها عمود في الداتا بيز
        //IFormFile مربوطه بجزء الفرونت الي بيتضاف ف تاج الفورم
        public IFormFile? ImageFile { get; set; }
        //بيحط العنوان الي موجود ف الroot بعد م الصوره تترفع
        public string? ImageUrl { get; set; } = "https://via.placeholder.com/150";


    }
}
