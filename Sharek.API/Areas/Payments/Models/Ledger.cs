public class Ledger
{
    public int LedgerId { get; set; }
    public int WalletId { get; set; }
    public string TransactionType { get; set; } // Deposit, Withdraw, EscrowHold
    public double Amount { get; set; }
    public string ReferenceId { get; set; } // OrderId أو PaymentId
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}