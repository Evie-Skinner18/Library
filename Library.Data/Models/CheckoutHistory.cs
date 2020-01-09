using System;
using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models
{
    public class CheckoutHistory
    {
        public int Id { get; set; }

        [Required]
        public LibraryItem Item { get; set; }

        public LibraryCard LibraryCard { get; set; }

        public DateTime DateCheckedOut { get; set; }

        public DateTime? DateCheckedIn { get; set; }
    }
}
