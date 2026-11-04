using SHAREK.Domain.Features.Disputes.Enums;

namespace SHAREK.Domain.Features.Disputes.Entities;

public sealed class DamageAssessment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid RentOrderId { get; set; }
    public decimal? Score { get; set; }
    public string? Notes { get; set; }
    public DamageAssessmentStatus Status { get; set; } = DamageAssessmentStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? DecidedByAdminId { get; set; }
    public decimal? DeductedAmount { get; set; }
    public string? DecisionNote { get; set; }
    public DateTime? DecidedAt { get; set; }
}
