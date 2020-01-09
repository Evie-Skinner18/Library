using System;
using LibraryData.Models.Common;

namespace LibraryData.Models
{
    public class Reserve
    {
        public int Id { get; set; }

        public virtual LibraryItem Item { get; set; }

        public virtual LibraryCard LibraryCard { get; set; }

        public DateTime DateReserved { get; set; }
    }
}
