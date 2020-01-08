using System;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {    
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
