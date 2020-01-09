using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models.LibraryItems
{
    public class Book : LibraryItem, IBorrowable
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        public string Borrow()
        {
            return "You have borrowed a book!";
        }

        public string Return()
        {
            return "Thank you for returning that book!";
        }

        public string Review(int numberOfStars)
        {
            return $"Thank you for giving this book {numberOfStars} stars!";
        }
    }

}
