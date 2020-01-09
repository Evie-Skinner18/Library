using LibraryData.Models;
using LibraryData.Models.Common;
using LibraryData.Models.LibraryItems;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        // ctor invokes base class ctor
        public LibraryContext(DbContextOptions options) : base(options) { }

        // all the tables we need representing the different resources
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cd> Cds { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<BranchHour> BranchHours { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<LibraryItemStatus> LibraryItemStatuses { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
    }
}
