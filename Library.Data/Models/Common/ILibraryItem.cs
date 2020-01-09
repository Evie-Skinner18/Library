namespace LibraryData.Models.Common
{
    public interface ILibraryItem
    {
        string Borrow();
        string Return();
        string Review();
    }
}
