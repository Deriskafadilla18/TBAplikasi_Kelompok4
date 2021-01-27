using Microsoft.EntityFrameworkCore;
using AplikasiPerpustakaan.Models;

namespace AplikasiPerpustakaan.Data
{
    public class DbContextBook : DbContext
    {
        public DbContextBook(DbContextOptions<DbContextBook> options)
            : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Borrow> Borrow { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Return> Return { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Borrow>().ToTable("Borrow");
            modelBuilder.Entity<Return>().ToTable("Return");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
        }

    }
}