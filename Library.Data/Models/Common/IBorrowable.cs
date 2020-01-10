﻿using System.Collections.Generic;

namespace LibraryData.Models.Common
{
    // any service that implements this interface will need these methods
    public interface IBorrowable
    {
        IEnumerable<LibraryItem> GetAllItems();
        LibraryItem GetItemById(int id);
        void AddItem(LibraryItem newLibraryItem);

        string GetAuthorOrDirector(int id);
        string GetGenreOrTopic(int id);
        string GetIsbn(int id);
        string GetTitle(int id);
        string GetItemType(int id);

        LibraryBranch GetItemLocation(int id);

        //    string Borrow();
        //    string Return();
        //    string Review(int numberOfStars);
    }
}
