using System.ComponentModel.DataAnnotations;
using LibraryData.Models.Common;

namespace LibraryData.Models.LibraryItems
{
    public class Video : LibraryItem, IBorrowable
    {
        public string Director { get; set; }

        public string Borrow()
        {
            return "You have borrowed a video!";
        }

        public string Return()
        {
            throw new System.NotImplementedException();
        }

        public string Review()
        {
            throw new System.NotImplementedException();
        }
    }

}
