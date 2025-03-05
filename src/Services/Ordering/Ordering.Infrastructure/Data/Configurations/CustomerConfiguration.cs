using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Id).HasConversion(x => x.Id, y => new CustomerId(y)).ValueGeneratedOnAdd();
        builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
    }
}