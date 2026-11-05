using Microsoft.EntityFrameworkCore;
using Sharek.API.Areas.Identity.Models;
using Sharek.API.Areas.Catalog.Models;
using Sharek.API.Areas.OrdersAndCommunication.Models;
using Sharek.API.Areas.Payments.Models;

namespace Sharek.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserVerification> UserVerifications { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ConditionPhoto> ConditionPhotos { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Swap> Swaps { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ConversationParticipant> ConversationParticipants { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConversationParticipant>()
                .HasKey(cp => new { cp.UserId, cp.ConversationId });

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Rent>().ToTable("Rents");
            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Swap>().ToTable("Swaps");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithMany(u => u.BuyerOrders)
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Seller)
                .WithMany(u => u.SellerOrders)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}