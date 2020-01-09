using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models.Common
{
    public abstract class LibraryItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public LibraryItemStatus ItemStatus { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string ImageUrl { get; set; }

        public int NumberOfCopies { get; set; }

        // foreign key in library branch table
        public virtual LibraryBranch Location { get; set; }

    }


}
