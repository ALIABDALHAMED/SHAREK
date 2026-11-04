using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.Domain.Features.Disputes.Entities;
using SHAREK.Domain.Features.Identity.Entities;
using SHAREK.Domain.Features.Orders.Entities;

namespace SHAREK.Infrastructure.Features.Disputes.Configurations;

public sealed class ConditionPhotoConfiguration : IEntityTypeConfiguration<ConditionPhoto>
{
    public void Configure(EntityTypeBuilder<ConditionPhoto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Phase).HasConversion<string>();
        builder.Property(x => x.TakenAt).HasColumnType("datetime2");
        builder.HasOne<Rent>().WithMany().HasForeignKey(x => x.RentOrderId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UploadedBy).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.RentOrderId);
        builder.HasIndex(x => x.UploadedBy);
    }
}

public sealed class DamageAssessmentConfiguration : IEntityTypeConfiguration<DamageAssessment>
{
    public void Configure(EntityTypeBuilder<DamageAssessment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Score).HasPrecision(5, 2);
        builder.Property(x => x.DeductedAmount).HasPrecision(18, 2);
        builder.Property(x => x.Status).HasConversion<string>();
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.DecidedAt).HasColumnType("datetime2");
        builder.HasOne<Rent>().WithMany().HasForeignKey(x => x.RentOrderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.DecidedByAdminId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.RentOrderId);
        builder.HasIndex(x => x.DecidedByAdminId);
    }
}
