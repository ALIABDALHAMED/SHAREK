namespace SHAREK.API.Modules.Orders.Enums;

public enum OrderType
{
    Rent,
    Sale,
    Swap
}

public enum OrderStatus
{
    Pending,
    Confirmed,
    Active,
    ReturnRequested,
    Disputed,
    Completed,
    Cancelled
}

public enum DepositStatus
{
    Held,
    Released,
    Deducted
}

public enum SwapStatus
{
    Pending,
    Accepted,
    Rejected,
    Cancelled,
    Completed
}
