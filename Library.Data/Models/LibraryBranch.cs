using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        [StringLength (30, ErrorMessage = "Please give a branch name of fewer than thirty characters")]
        public object Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public DateTime DateOpened { get; set; }

        // collection of customers belonging to this lib
        public IEnumerable<Customer> Customers { get; set; }

        // collection of items belonging to this lib
        public IEnumerable<LibraryItem> LibraryItems { get; set; }

        public string ImageUrl { get; set; }
    }
}
