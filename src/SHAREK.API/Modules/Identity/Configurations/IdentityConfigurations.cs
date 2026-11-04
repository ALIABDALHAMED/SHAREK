using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.API.Modules.Identity.Entities;
using SHAREK.API.Modules.Identity.Enums;

namespace SHAREK.API.Modules.Identity.Configurations;

public sealed class IdentityUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder) =>
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
}

public sealed class IdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder) =>
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
}

public sealed class IdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder) =>
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
}

public sealed class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<IdentityRole<Guid>>().WithMany().HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class IdentityRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> builder) =>
        builder.HasOne<IdentityRole<Guid>>().WithMany().HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
}

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.VerifiedStatus).HasConversion<string>().HasDefaultValue(VerificationStatus.Pending);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.DateOfBirth).HasColumnType("datetime2");
        builder.Property(x => x.ListingSuspendedUntil).HasColumnType("datetime2");
        builder.Property(x => x.DeletionRequestedAt).HasColumnType("datetime2");
    }
}

public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExpiresAt).HasColumnType("datetime2");
        builder.Property(x => x.RevokedAt).HasColumnType("datetime2");
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.UserId);
    }
}

public sealed class UserVerificationConfiguration : IEntityTypeConfiguration<UserVerification>
{
    public void Configure(EntityTypeBuilder<UserVerification> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.Status).HasConversion<string>();
        builder.Property(x => x.SubmittedAt).HasColumnType("datetime2");
        builder.Property(x => x.ReviewedAt).HasColumnType("datetime2");
        builder.HasOne<User>().WithOne().HasForeignKey<UserVerification>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.ReviewedByAdminId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.ReviewedByAdminId);
    }
}
