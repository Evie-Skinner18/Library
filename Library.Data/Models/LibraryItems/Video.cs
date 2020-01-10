using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models.LibraryItems
{
    public class Video : LibraryItem
    {
        [Required]
        public string Director { get; set; }

        [Required]
        public string FilmGenre { get; set; }


        //public string Borrow()
        //{
        //    return "You have borrowed a video!";
        //}

        //public string Return()
        //{
        //    return "Thank you for returning that video!";
        //}

        //public string Review(int numberOfStars)
        //{
        //    return $"Thank you for giving this video {numberOfStars} stars!";
        //}
    }


}
