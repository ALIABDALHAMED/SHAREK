using SHAREK.Domain.Features.Orders.Enums;

namespace SHAREK.Domain.Features.Orders.Entities;

public sealed class Swap
{
    public Guid OrderId { get; set; }
    public Guid TargetProductId { get; set; }
    public Guid OfferedProductId { get; set; }
    public SwapStatus Status { get; set; } = SwapStatus.Pending;
    public DateTime? AcceptedAt { get; set; }
}
