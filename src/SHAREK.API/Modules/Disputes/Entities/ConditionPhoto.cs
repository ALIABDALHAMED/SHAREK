using SHAREK.API.Modules.Disputes.Enums;

namespace SHAREK.API.Modules.Disputes.Entities;

public sealed class ConditionPhoto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid RentOrderId { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public ConditionPhase Phase { get; set; }
    public Guid UploadedBy { get; set; }
    public DateTime TakenAt { get; set; }
}
