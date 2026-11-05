using Sharek.API.Areas.Catalog.Models;
using Sharek.API.Areas.OrdersAndCommunication.Models;
using System.ComponentModel.DataAnnotations;

namespace Sharek.API.Areas.Identity.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ProfilePhoto { get; set; }

        [Required]
        public string Role { get; set; } = "User"; // Admin, User

        public string ValidationStatus { get; set; } = "Pending"; // Pending, Approved, Rejected
        public bool VerifiedStatus { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties    (relationships)
        public UserVerification? UserVerification { get; set; }
        public ICollection<Product> Products { get; set; } 
        public ICollection<Order> BuyerOrders { get; set; }
        public ICollection<Order> SellerOrders { get; set; }
    }
}