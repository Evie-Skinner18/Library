﻿using System;
using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        [Required]
        public LibraryItem Item { get; set; }

        public LibraryCard LibraryCard { get; set; }

        public DateTime BorrowingDate { get; set; }

        public DateTime DueDate { get; set; }

    }
}
