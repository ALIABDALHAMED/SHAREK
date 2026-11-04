namespace SHAREK.Domain.Features.Wallet.Enums;

public enum LedgerEntryType
{
    TopUp,
    Rent,
    Deposit,
    Release,
    Fee,
    LateFee,
    Refund,
    Payout,
    Hold
}

public enum PaymentType
{
    TopUp,
    Rent,
    Deposit,
    Sale
}

public enum PaymentStatus
{
    Pending,
    Succeeded,
    Failed
}

public enum WithdrawalStatus
{
    Pending,
    Approved,
    Rejected
}
