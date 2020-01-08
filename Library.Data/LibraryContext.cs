using System;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            // "User ID=eves;Password=coucou;Server=localhost;Port=5432;Database=Library;Integrated Security=true;Pooling=true;"
            => optionsBuilder.UseNpgsql("Host=localhost;Database=Library;Username=eves;Password=coucou");

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

    }
}
