using Microsoft.AspNetCore.Identity;

namespace Shoopify.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
