using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Entities.Configurations
{
    internal class DecommissionedBookEntityTypeConfiguration : IEntityTypeConfiguration<DecommissionedBook>
    {
        public void Configure(EntityTypeBuilder<DecommissionedBook> builder)
        {
            builder.HasKey(e => e.BookId)
                .HasName("PK__Decommis__3DE0C2077B695AC9");

            builder.ToTable("DecommissionedBook");

            builder.Property(e => e.BookId).ValueGeneratedNever();

            builder.HasOne(d => d.Book)
                .WithOne(p => p.DecommissionedBook)
                .HasForeignKey<DecommissionedBook>(d => d.BookId)
                .HasConstraintName("DecommissionedBook_BookId_Book_id");
        }
    }
}