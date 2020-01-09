using LibraryData.Models.Common;

namespace LibraryData.Models.LibraryItems
{
    public class Cd : LibraryItem, IBorrowable
    {
        public string Borrow()
        {
            throw new System.NotImplementedException();
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
