namespace SHAREK.API.Modules.Admin.Entities;

public sealed class AuditLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid AdminId { get; set; }

    public Guid? TargetUserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string? Details { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
