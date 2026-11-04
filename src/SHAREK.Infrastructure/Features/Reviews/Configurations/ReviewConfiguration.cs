using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.Domain.Features.Identity.Entities;
using SHAREK.Domain.Features.Orders.Entities;
using SHAREK.Domain.Features.Products.Entities;
using SHAREK.Domain.Features.Reviews.Entities;

namespace SHAREK.Infrastructure.Features.Reviews.Configurations;

public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.ToTable(table => table.HasCheckConstraint("CK_Reviews_Rating", "[Rating] >= 1 AND [Rating] <= 5"));
        builder.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.ReviewerUserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.RevieweeUserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => new { x.OrderId, x.ReviewerUserId }).IsUnique();
        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.ReviewerUserId);
        builder.HasIndex(x => x.RevieweeUserId);
        builder.HasIndex(x => x.ProductId);
    }
}
