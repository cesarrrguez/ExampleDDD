using ExampleDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExampleDDD.Infrastructure.Data.Context;

namespace ExampleDDD.Infrastructure.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", DataContext.DefaultSchema);

            // Primary Key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Age)
                .IsRequired();

            builder.Property(u => u.State)
                .IsRequired();

            // Relationships
            builder.OwnsOne(u => u.PhoneNumber)
                .Property(pn => pn.Number)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(10)
                .IsRequired();

            builder.Navigation(u => u.PhoneNumber)
                .IsRequired();
        }
    }
}
