using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Id, y => new OrderId(y)).ValueGeneratedOnAdd();;
        builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
        builder.HasMany(x => x.OrderItems).WithOne().HasForeignKey(x => x.OrderId);
        
        builder.ComplexProperty(x => x.OrderName, complexity =>
        {
            complexity.Property(p => p.Value)
                .HasColumnName(nameof(Order.OrderName))
                .HasMaxLength(100)
                .IsRequired();
        });
        
        builder.ComplexProperty(x => x.ShippingAddress, complexity =>
        {
            complexity.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.EmailAddress).HasMaxLength(50);
            complexity.Property(x => x.AddressLine).HasMaxLength(200).IsRequired();
            complexity.Property(x => x.Country).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.State).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.ZipCode).HasMaxLength(10).IsRequired();
        });
        
        builder.ComplexProperty(x => x.BillingAddress, complexity =>
        {
            complexity.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.EmailAddress).HasMaxLength(50);
            complexity.Property(x => x.AddressLine).HasMaxLength(200).IsRequired();
            complexity.Property(x => x.Country).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.State).HasMaxLength(50).IsRequired();
            complexity.Property(x => x.ZipCode).HasMaxLength(10).IsRequired();
        });

        builder.ComplexProperty(x => x.Payment, y =>
        {
            y.Property(x => x.CardName).HasMaxLength(50).IsRequired();
            y.Property(x => x.CardNumber).HasMaxLength(24).IsRequired();
            y.Property(x => x.Expiration).HasMaxLength(10).IsRequired();
            y.Property(x => x.CVV).HasMaxLength(3).IsRequired();
            y.Property(x => x.PaymentMethod);
        });
        
        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(s => s.ToStringEnum(), s => Enum.Parse<OrderStatus>(s));

        builder.Property(x => x.OrderTotal);
    }
}