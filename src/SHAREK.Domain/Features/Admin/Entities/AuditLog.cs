namespace SHAREK.Domain.Features.Admin.Entities;

public sealed class AuditLog
{
    public Guid Id { get; init; }

    public string Action { get; init; } = string.Empty;

    public string EntityName { get; init; } = string.Empty;

    public string EntityId { get; init; } = string.Empty;

    public string? UserId { get; init; }

    public DateTimeOffset OccurredAt { get; init; }
}
