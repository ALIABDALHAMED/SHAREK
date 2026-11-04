namespace SHAREK.API.Modules.Orders.Entities;

public sealed class Sale
{
    public Guid OrderId { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string SaleStatus { get; set; } = string.Empty;
}
