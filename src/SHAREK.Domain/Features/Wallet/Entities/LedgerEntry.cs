using SHAREK.Domain.Features.Wallet.Enums;

namespace SHAREK.Domain.Features.Wallet.Entities;

public sealed class LedgerEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public LedgerEntryType Type { get; set; }
    public Guid? OrderId { get; set; }
    public Guid? PaymentId { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
