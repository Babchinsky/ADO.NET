using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Entities.Configurations
{
    internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode();
        }
    }
}