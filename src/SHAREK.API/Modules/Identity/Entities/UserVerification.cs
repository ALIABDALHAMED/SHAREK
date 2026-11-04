using SHAREK.API.Modules.Identity.Enums;

namespace SHAREK.API.Modules.Identity.Entities;

public sealed class UserVerification
{
    public Guid UserId { get; set; }
    public string NationalId { get; set; } = string.Empty;
    public string IdImageFront { get; set; } = string.Empty;
    public string IdImageBack { get; set; } = string.Empty;
    public VerificationStatus Status { get; set; } = VerificationStatus.Pending;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    public Guid? ReviewedByAdminId { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public string? RejectionReason { get; set; }
}
