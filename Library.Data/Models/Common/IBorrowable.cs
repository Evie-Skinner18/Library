namespace LibraryData.Models.Common
{
    // any service that implements this interface will need these methods
    public interface IBorrowable
    {
        string Borrow();
        string Return();
        string Review(int numberOfStars);
    }   
}
