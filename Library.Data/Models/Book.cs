using LibraryData.Models.Common;

namespace LibraryData.Models
{
    public class Book : ILibraryItem
    {
        public string Borrow()
        {
            return "You have borrowed a book!";
        }

        public string Return()
        {
            return "Thank you for returning that book!";
        }

        public string Review()
        {
            throw new System.NotImplementedException();
        }
    }
}
