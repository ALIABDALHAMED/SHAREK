using Sharek.API.Areas.Identity.Models;
using Sharek.API.Areas.Payments.Models;

namespace Sharek.API.Areas.OrdersAndCommunication.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int BuyerId { get; set; }
        public int SellerId { get; set; }

        public int ProductId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User Buyer { get; set; }
        public User Seller { get; set; }

        public Rent? RentDetails { get; set; }
        public Sale? SaleDetails { get; set; }
        public Swap? SwapDetails { get; set; }
        public Payment? Payment { get; set; }
    }
}