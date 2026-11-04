namespace SHAREK.Infrastructure.Payments.MockGateway;

public sealed class MockPaymentGateway
{
    public Task<MockPaymentResult> ProcessPaymentAsync(
        decimal amount,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Payment amount must be positive.");
        }

        return Task.FromResult(new MockPaymentResult(true, $"mock-{Guid.NewGuid():N}"));
    }
}

public sealed record MockPaymentResult(bool IsSuccessful, string TransactionId);
