namespace SHAREK.API.Modules.Wallet.Entities;

public sealed class Wallet
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? UserId { get; set; }
    public bool IsPlatform { get; set; }
}
