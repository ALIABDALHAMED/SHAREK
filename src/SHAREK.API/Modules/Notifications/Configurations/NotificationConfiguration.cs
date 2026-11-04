using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.API.Modules.Identity.Entities;
using SHAREK.API.Modules.Notifications.Entities;
using SHAREK.API.Modules.Orders.Entities;

namespace SHAREK.API.Modules.Notifications.Configurations;

public sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Order>().WithMany().HasForeignKey(x => x.RelatedOrderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.RelatedOrderId);
    }
}
