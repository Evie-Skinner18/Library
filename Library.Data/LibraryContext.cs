using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

    }
}
