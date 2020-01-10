using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models.LibraryItems
{
    public class Cd : LibraryItem
    {
        [Required]
        public string Artist { get; set; }

        [Required]
        public string MusicGenre { get; set; }

        //public string Borrow()
        //{
        //    return "You have borrowed a CD";
        //}

        //public string Return()
        //{
        //    return "Thank you for returning that CD!";
        //}

        //public string Review(int numberOfStars)
        //{
        //    return $"Thank you for giving this CD {numberOfStars} stars!";
        //}
    }
}
