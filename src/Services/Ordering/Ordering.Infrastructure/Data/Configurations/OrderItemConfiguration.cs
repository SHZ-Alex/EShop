using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Id, y => new OrderItemId(y)).ValueGeneratedOnAdd();
        builder.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired();
    }
}