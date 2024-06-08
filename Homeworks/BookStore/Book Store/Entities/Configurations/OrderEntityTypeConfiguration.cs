using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Entities.Configurations
{
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => new { e.BookId, e.CustomerId })
                .HasName("PK__Order__A7AA244A0ABE3634");

            builder.ToTable("Order");

            builder.Property(e => e.EndDate).HasColumnType("datetime");

            builder.HasOne(d => d.Book)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("Order_BookId_Book_id");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("Order_CustomerId_Customer_Id");
        }
    }
}