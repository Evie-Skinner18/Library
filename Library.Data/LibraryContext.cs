using System;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=my_host;Database=Library;Username=my_user;Password=my_pw");

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

    }
}
