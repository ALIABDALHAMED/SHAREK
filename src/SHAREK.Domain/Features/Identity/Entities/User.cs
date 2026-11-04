using Microsoft.AspNetCore.Identity;

namespace SHAREK.Domain.Features.Identity.Entities;

public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
