using System;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=Library;Username=eves;Password=coucou");

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

    }
}
