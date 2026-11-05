namespace Sharek.API.Areas.Payments.Models;
public class Payment
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public int PayerUserId { get; set; }
    public double Amount { get; set; }
    public string Method { get; set; } // Card, Wallet
    public string Status { get; set; }
    public string OTP { get; set; } // for Hashed OTP
    public DateTime CreatedAt { get; set; }
    public DateTime? ReleasedAt { get; set; }
}