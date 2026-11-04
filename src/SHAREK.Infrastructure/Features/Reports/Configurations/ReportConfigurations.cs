using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.Domain.Features.Identity.Entities;
using SHAREK.Domain.Features.Messaging.Entities;
using SHAREK.Domain.Features.Orders.Entities;
using SHAREK.Domain.Features.Products.Entities;
using SHAREK.Domain.Features.Reports.Entities;

namespace SHAREK.Infrastructure.Features.Reports.Configurations;

public sealed class ReportTypeConfiguration : IEntityTypeConfiguration<ReportType>
{
    public void Configure(EntityTypeBuilder<ReportType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.TypeName).IsUnique();
    }
}

public sealed class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion<string>();
        builder.Property(x => x.Penalty).HasPrecision(18, 2);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.ResolvedAt).HasColumnType("datetime2");
        builder.ToTable(table => table.HasCheckConstraint(
            "CK_Reports_ReportedEntity",
            "[ProductId] IS NOT NULL OR [OrderId] IS NOT NULL OR [MessageId] IS NOT NULL"));
        builder.HasOne<ReportType>().WithMany().HasForeignKey(x => x.ReportTypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.ReporterUserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Message>().WithMany().HasForeignKey(x => x.MessageId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.ResolvedByAdminId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.ReportTypeId);
        builder.HasIndex(x => x.ReporterUserId);
        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.MessageId);
        builder.HasIndex(x => x.ResolvedByAdminId);
    }
}

public sealed class RegularReportConfiguration : IEntityTypeConfiguration<RegularReport>
{
    public void Configure(EntityTypeBuilder<RegularReport> builder)
    {
        builder.HasKey(x => x.ReportId);
        builder.HasOne<Report>().WithOne().HasForeignKey<RegularReport>(x => x.ReportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class DamageReportConfiguration : IEntityTypeConfiguration<DamageReport>
{
    public void Configure(EntityTypeBuilder<DamageReport> builder)
    {
        builder.HasKey(x => x.ReportId);
        builder.HasOne<Report>().WithOne().HasForeignKey<DamageReport>(x => x.ReportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
