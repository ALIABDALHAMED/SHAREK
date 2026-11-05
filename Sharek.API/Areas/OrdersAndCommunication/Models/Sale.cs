using Sharek.API.Areas.OrdersAndCommunication.Models;

public class Sale
{
    public int SaleId { get; set; }
    public int OrderId { get; set; }
    public string PaymentMethod { get; set; }
    public string SaleStatus { get; set; }
    public Order Order { get; set; }
}
