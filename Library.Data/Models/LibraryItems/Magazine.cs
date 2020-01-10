using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models.LibraryItems
{
    public class Magazine : LibraryItem
    {
        [Required]
        public string Topic { get; set; }

        public bool HasCollectibleInside { get; set; }

        //public string Borrow()
        //{
        //    return "You have borrowed a magazine";
        //}

        //public string Return()
        //{
        //    return "Thank you for returning that magazine!";
        //}

        //public string Review(int numberOfStars)
        //{
        //    return $"Thank you for giving this magazine {numberOfStars} stars!";
        //}
    }


}
