using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExampleDDD.Domain.Entities;
using ExampleDDD.Infrastructure.Data.Context;

namespace ExampleDDD.Infrastructure.Data.Mappings
{
    public class UserEmailMap : IEntityTypeConfiguration<UserEmail>
    {
        public void Configure(EntityTypeBuilder<UserEmail> builder)
        {
            builder.ToTable("UserEmails", DataContext.DefaultSchema);

            // Primary Key
            builder.HasKey(ue => ue.Id);

            // Relationships
            builder.OwnsOne(ue => ue.Email)
                .Property(e => e.EmailAddress)
                .HasColumnName("Email")
                .HasMaxLength(200)
                .IsRequired();

            builder.Navigation(ue => ue.Email)
                .IsRequired();

            builder.HasOne(ue => ue.User)
                .WithMany(ue => ue.Emails)
                .IsRequired();
        }
    }
}
