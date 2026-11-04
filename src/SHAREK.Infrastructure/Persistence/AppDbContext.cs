using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHAREK.Domain.Features.Admin.Entities;
using SHAREK.Domain.Features.Disputes.Entities;
using SHAREK.Domain.Features.Identity.Entities;
using SHAREK.Domain.Features.Messaging.Entities;
using SHAREK.Domain.Features.Notifications.Entities;
using SHAREK.Domain.Features.Orders.Entities;
using SHAREK.Domain.Features.Products.Entities;
using SHAREK.Domain.Features.Reports.Entities;
using SHAREK.Domain.Features.Reviews.Entities;
using SHAREK.Domain.Features.Wallet.Entities;

namespace SHAREK.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    // Add each new entity's DbSet here.
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<UserVerification> UserVerifications => Set<UserVerification>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Rent> Rents => Set<Rent>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Swap> Swaps => Set<Swap>();
    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<LedgerEntry> LedgerEntries => Set<LedgerEntry>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<WithdrawalRequest> WithdrawalRequests => Set<WithdrawalRequest>();
    public DbSet<ConditionPhoto> ConditionPhotos => Set<ConditionPhoto>();
    public DbSet<DamageAssessment> DamageAssessments => Set<DamageAssessment>();
    public DbSet<Conversation> Conversations => Set<Conversation>();
    public DbSet<ConversationParticipant> ConversationParticipants => Set<ConversationParticipant>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<UserBlock> UserBlocks => Set<UserBlock>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ReportType> ReportTypes => Set<ReportType>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<RegularReport> RegularReports => Set<RegularReport>();
    public DbSet<DamageReport> DamageReports => Set<DamageReport>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
