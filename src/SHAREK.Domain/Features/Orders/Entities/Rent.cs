using SHAREK.Domain.Features.Orders.Enums;

namespace SHAREK.Domain.Features.Orders.Entities;

public sealed class Rent
{
    public Guid OrderId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DailyPrice { get; set; }
    public decimal DepositAmount { get; set; }
    public DepositStatus DepositStatus { get; set; } = DepositStatus.Held;
    public decimal LateFeeMultiplier { get; set; }
    public DateTime? PickedUpAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public DateTime? DisputeOpenedAt { get; set; }
}
