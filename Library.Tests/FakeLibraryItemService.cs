using System.Collections.Generic;
using LibraryData.Models;
using LibraryData.Models.Common;

namespace Library.Tests
{
    public class FakeLibraryItemService : IBorrowable
    {
        public void AddItem(LibraryItem newLibraryItem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LibraryItem> GetAllItems()
        {
            throw new System.NotImplementedException();
        }

        public string GetAuthorDirectorOrArtist(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetGenreOrTopic(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetIsbn(int id)
        {
            throw new System.NotImplementedException();
        }

        public LibraryItem GetItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public LibraryBranch GetItemLocation(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetItemType(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}