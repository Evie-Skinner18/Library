using System.Collections.Generic;
using LibraryData.Models.Common;
using LibraryData.Models.LibraryItems;
using NUnit.Framework;

namespace Library.Tests
{
    public class LibraryItemServiceTests
    {
        private IBorrowable _fakeLibraryService;
        private List<LibraryItem> _libraryItems;

        [SetUp]
        public void Setup()
        {
            _fakeLibraryService = new FakeLibraryItemService();
            _libraryItems = new List<LibraryItem>()
            {
                new Book()
                {
                    Title = "On the Road",
                    Author = "Jack Kerouac",
                    Id = 1111111,
                    Year = 1959,


                }
            };
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}