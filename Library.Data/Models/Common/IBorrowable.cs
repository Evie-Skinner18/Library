namespace LibraryData.Models.Common
{
    public interface IBorrowable
    {
        string Borrow();
        string Return();
        string Review(int numberOfStars);
    }   
}
