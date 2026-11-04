using Microsoft.AspNetCore.Identity;
using SHAREK.API.Modules.Identity.Enums;

namespace SHAREK.API.Modules.Identity.Entities;

public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Governorate { get; set; }

    public string? Language { get; set; }

    public string? ProfilePhoto { get; set; }

    public string? Personalization { get; set; }

    public VerificationStatus VerifiedStatus { get; set; } = VerificationStatus.Pending;

    public DateTime? ListingSuspendedUntil { get; set; }

    public int SuspensionCount { get; set; }

    public DateTime? DeletionRequestedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
