using Sharek.API.Areas.Identity.Models;
using Sharek.API.Areas.OrdersAndCommunication.Models;

namespace Sharek.API.Areas.Catalog.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int OwnerUserId { get; set; } // FK for User
        public int CategoryId { get; set; } // FK for Category
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ListingType { get; set; } // Rent, Sale, Swap
        public string Location { get; set; }
        public string Status { get; set; } // Available, Rented, Sold
        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        // Navigation
        public User Owner { get; set; } 
        public Category Category { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}