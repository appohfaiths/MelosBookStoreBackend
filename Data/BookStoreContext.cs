using Microsoft.EntityFrameworkCore;
using MelosBookStore.Models;

namespace MelosBookStore.Data
{
        public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options): base(options) {}
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookSeller> BookSellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<User> Users { get; set; }

             protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(pc => new {pc.AuthorId, pc.BookId});
            modelBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Author)
                .WithMany(pc => pc.BookAuthors)
                .HasForeignKey(p => p.AuthorId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(p => p.Book)
                .WithMany(pc => pc.BookAuthors)
                .HasForeignKey(c => c.BookId);
                 
            modelBuilder.Entity<BookCategory>()
                .HasKey(po => new {po.CategoryId, po.BookId});
            modelBuilder.Entity<BookCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.BookCategories)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(p => p.Book)
                .WithMany(pc => pc.BookCategories)
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<BookSeller>()
                .HasKey(po => new {po.SellerId, po.BookId});
            modelBuilder.Entity<BookSeller>()
                .HasOne(p => p.Seller)
                .WithMany(pc => pc.BookSellers)
                .HasForeignKey(p => p.SellerId);
            modelBuilder.Entity<BookSeller>()
                .HasOne(p => p.Book)
                .WithMany(pc => pc.BookSellers)
                .HasForeignKey(c => c.BookId);

                modelBuilder.Entity<Book>()
        .HasKey(b => b.Id);
                modelBuilder.Entity<Author>()
        .HasKey(a => a.Id);
                modelBuilder.Entity<Category>()
        .HasKey(c => c.Id);
                modelBuilder.Entity<User>()
        .HasKey(u => u.Id);
        }
    }
}