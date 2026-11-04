using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHAREK.API.Modules.Identity.Entities;
using SHAREK.API.Modules.Messaging.Entities;
using SHAREK.API.Modules.Products.Entities;

namespace SHAREK.API.Modules.Messaging.Configurations;

public sealed class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.LastMessageAt).HasColumnType("datetime2");
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.BuyerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.SellerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => new { x.BuyerId, x.SellerId, x.ProductId }).IsUnique();
        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => x.BuyerId);
        builder.HasIndex(x => x.SellerId);
    }
}

public sealed class ConversationParticipantConfiguration : IEntityTypeConfiguration<ConversationParticipant>
{
    public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
    {
        builder.HasKey(x => new { x.ConversationId, x.UserId });
        builder.Property(x => x.JoinedAt).HasColumnType("datetime2");
        builder.Property(x => x.LastReadAt).HasColumnType("datetime2");
        builder.HasOne<Conversation>().WithMany().HasForeignKey(x => x.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.UserId);
    }
}

public sealed class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SentAt).HasColumnType("datetime2");
        builder.HasOne<Conversation>().WithMany().HasForeignKey(x => x.ConversationId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.SenderUserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.ConversationId);
        builder.HasIndex(x => x.SenderUserId);
    }
}

public sealed class UserBlockConfiguration : IEntityTypeConfiguration<UserBlock>
{
    public void Configure(EntityTypeBuilder<UserBlock> builder)
    {
        builder.HasKey(x => new { x.BlockerId, x.BlockedId });
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.BlockerId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.BlockedId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.BlockedId);
    }
}
