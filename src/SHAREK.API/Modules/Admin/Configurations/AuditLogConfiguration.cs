using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.API.Modules.Admin.Entities;
using SHAREK.API.Modules.Identity.Entities;

namespace SHAREK.API.Modules.Admin.Configurations;

public sealed class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.AdminId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.TargetUserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.AdminId);
        builder.HasIndex(x => x.TargetUserId);
    }
}
