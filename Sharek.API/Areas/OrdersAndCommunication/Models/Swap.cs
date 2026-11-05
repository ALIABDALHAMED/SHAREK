using Sharek.API.Areas.OrdersAndCommunication.Models;

public class Swap
{
    public int SwapId { get; set; }
    public int OrderId { get; set; }
    public int OfferedProductId { get; set; } // The product that the user is offering in exchange
    public DateTime TimeAcceptedAt { get; set; }
    public Order Order { get; set; }
}