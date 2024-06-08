using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Entities.Configurations
{
    internal class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");

            builder.Property(e => e.ImageTitle)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(e => e.ImageData)
                .IsRequired();
        }
    }
}