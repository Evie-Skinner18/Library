using System;
using System.Collections.Generic;

namespace LibraryData.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }

        public decimal FeesOwed { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<Checkout> Checkouts { get; set; }
    }
}
