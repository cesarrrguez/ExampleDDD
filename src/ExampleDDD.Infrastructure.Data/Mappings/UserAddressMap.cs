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

            // Relationships
            builder.OwnsOne(
                ua => ua.Address,
                navigationBuilder =>
                {
                    navigationBuilder.Property(a => a.Street)
                        .HasColumnName("Street")
                        .HasMaxLength(200)
                        .IsRequired();

                    navigationBuilder.Property(a => a.City)
                        .HasColumnName("City")
                        .HasMaxLength(100)
                        .IsRequired();

                    navigationBuilder.Property(a => a.State)
                        .HasColumnName("State")
                        .HasMaxLength(50)
                        .IsRequired();

                    navigationBuilder.Property(a => a.Country)
                        .HasColumnName("Country")
                        .HasMaxLength(50)
                        .IsRequired();

                    navigationBuilder.Property(a => a.ZipCode)
                        .HasColumnName("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .IsRequired();
                }
            );

            builder.Navigation(ua => ua.Address)
                .IsRequired();

            builder.HasOne(ua => ua.User)
                .WithMany(ua => ua.Addresses)
                .IsRequired();
        }
    }
}
