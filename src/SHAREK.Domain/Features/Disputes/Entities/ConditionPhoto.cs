using SHAREK.Domain.Features.Disputes.Enums;

namespace SHAREK.Domain.Features.Disputes.Entities;

public sealed class ConditionPhoto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid RentOrderId { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public ConditionPhase Phase { get; set; }
    public Guid UploadedBy { get; set; }
    public DateTime TakenAt { get; set; }
}
