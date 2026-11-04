using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.API.Modules.Identity.Entities;
using SHAREK.API.Modules.Orders.Entities;
using SHAREK.API.Modules.Products.Entities;

namespace SHAREK.API.Modules.Orders.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type).HasConversion<string>();
        builder.Property(x => x.Status).HasConversion<string>();
        builder.Property(x => x.TotalPrice).HasPrecision(18, 2);
        builder.Property(x => x.FeePercent).HasPrecision(5, 2);
        builder.Property(x => x.RefundedAmount).HasPrecision(18, 2);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.HandoverConfirmedAt).HasColumnType("datetime2");
        builder.Property(x => x.CancelledAt).HasColumnType("datetime2");
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.BuyerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.SellerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.CancelledBy).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.BuyerId);
        builder.HasIndex(x => x.SellerId);
        builder.HasIndex(x => x.CancelledBy);
    }
}

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Price).HasPrecision(18, 2);
        builder.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.ProductId);
    }
}

public sealed class RentConfiguration : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.Property(x => x.DepositStatus).HasConversion<string>();
        builder.Property(x => x.DailyPrice).HasPrecision(18, 2);
        builder.Property(x => x.DepositAmount).HasPrecision(18, 2);
        builder.Property(x => x.LateFeeMultiplier).HasPrecision(5, 2);
        builder.Property(x => x.StartDate).HasColumnType("datetime2");
        builder.Property(x => x.EndDate).HasColumnType("datetime2");
        builder.Property(x => x.PickedUpAt).HasColumnType("datetime2");
        builder.Property(x => x.ReturnedAt).HasColumnType("datetime2");
        builder.Property(x => x.DisputeOpenedAt).HasColumnType("datetime2");
        builder.HasOne<Order>().WithOne().HasForeignKey<Rent>(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.HasOne<Order>().WithOne().HasForeignKey<Sale>(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class SwapConfiguration : IEntityTypeConfiguration<Swap>
{
    public void Configure(EntityTypeBuilder<Swap> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.Property(x => x.Status).HasConversion<string>();
        builder.Property(x => x.AcceptedAt).HasColumnType("datetime2");
        builder.HasOne<Order>().WithOne().HasForeignKey<Swap>(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.TargetProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.OfferedProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.TargetProductId);
        builder.HasIndex(x => x.OfferedProductId);
    }
}
