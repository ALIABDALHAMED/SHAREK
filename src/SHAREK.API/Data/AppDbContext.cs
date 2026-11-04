using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHAREK.API.Modules.Admin.Entities;
using SHAREK.API.Modules.Disputes.Entities;
using SHAREK.API.Modules.Identity.Entities;
using SHAREK.API.Modules.Messaging.Entities;
using SHAREK.API.Modules.Notifications.Entities;
using SHAREK.API.Modules.Orders.Entities;
using SHAREK.API.Modules.Products.Entities;
using SHAREK.API.Modules.Reports.Entities;
using SHAREK.API.Modules.Reviews.Entities;
using SHAREK.API.Modules.Wallet.Entities;

namespace SHAREK.API.Data;

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
