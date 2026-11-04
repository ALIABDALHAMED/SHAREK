using SHAREK.Domain.Features.Wallet.Enums;

namespace SHAREK.Domain.Features.Wallet.Entities;

public sealed class WithdrawalRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public WithdrawalStatus Status { get; set; } = WithdrawalStatus.Pending;
    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    public Guid? DecidedByAdminId { get; set; }
    public DateTime? DecidedAt { get; set; }
}
