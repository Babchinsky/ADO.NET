using Microsoft.EntityFrameworkCore;

namespace Autors_Books_EF_DatabaseFirst
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LEGION;Database=LibraryDB;Integrated Security=SSPI;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определяем связь "один ко многим" между таблицами Authors и Books
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books) // У одного автора может быть много книг
                .WithOne(b => b.Author) // Каждая книга принадлежит только одному автору
                .HasForeignKey(b => b.AuthorId); // Внешний ключ в таблице Books

            // Создание таблицы Authors
            modelBuilder.Entity<Author>()
                .ToTable("Authors")
                .HasKey(a => a.AuthorId);

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Name) // Создание индекса для поля Name
                .IsUnique(); // Поле Name должно быть уникальным

            // Создание таблицы Books
            modelBuilder.Entity<Book>()
                .ToTable("Books")
                .HasKey(b => b.BookId);

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
        }
    }

}
