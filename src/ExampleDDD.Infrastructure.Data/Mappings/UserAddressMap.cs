using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Infrastructure.Data.Context;

namespace ExampleDDD.Infrastructure.Data.Mappings
{
    public class UserAddressMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable("UserAddresses", DataContext.DefaultSchema);

            // Primary Key
            builder.HasKey(ua => ua.Id);

            // Properties
            builder.Property(ua => ua.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(ua => ua.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(ua => ua.State)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(ua => ua.Country)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(ua => ua.ZipCode)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)")
                .IsRequired();

            // Relationships
            builder.HasOne(ua => ua.User)
                .WithMany(ua => ua.Addresses)
                .IsRequired();
        }
    }
}
