using SHAREK.Domain.Features.Products.Enums;

namespace SHAREK.Domain.Features.Products.Entities;

public sealed class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OwnerUserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ListingType ListingType { get; set; }
    public decimal Price { get; set; }
    public decimal? DepositAmount { get; set; }
    public int Quantity { get; set; }
    public string City { get; set; } = string.Empty;
    public string Governorate { get; set; } = string.Empty;
    public ProductStatus Status { get; set; } = ProductStatus.Available;
    public bool IsHidden { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime PostDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
    public Guid? RemovedByAdminId { get; set; }
    public string? RemovalReason { get; set; }
}
