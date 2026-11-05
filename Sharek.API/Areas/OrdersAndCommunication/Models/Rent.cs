namespace Sharek.API.Areas.OrdersAndCommunication.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public int OrderId { get; set; } // FK for Order
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public double InsuranceAmount { get; set; }
        public string InsurancePhotoUrl { get; set; }
        public string InsuranceVideoUrl { get; set; }
        public bool RevolveRent { get; set; }

        public Order Order { get; set; }
    }
}