namespace Shoopify.Models.Entities
{
    public class Order //Main model (wich communicate with db directly)
    {

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Decimal TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new LinkedList<OrderItem>();
    }
}
