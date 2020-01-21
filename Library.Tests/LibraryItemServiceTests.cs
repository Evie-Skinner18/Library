using System;
using System.Collections.Generic;
using LibraryData.Models;
using LibraryData.Models.Common;
using LibraryData.Models.LibraryItems;
using NUnit.Framework;

namespace Library.Tests
{
    public class LibraryItemServiceTests
    {
        private IBorrowable _fakeLibraryService;
        private LibraryBranch _stroudBranch;
        private List<LibraryItem> _libraryItems;


        [SetUp]
        public void Setup()
        {
            _fakeLibraryService = new FakeLibraryItemService();
            // left out some of library branch properties like Customers
            _stroudBranch = new LibraryBranch()
            {
                Id = 1,
                Name = "Stroud Library",
                Address = "Landsdown, Stroud, GL5",
                Description = "The official library of the Republic",
                PhoneNumber = "01453 666 999",
                DateOpened = DateTime.Parse("14/02/1993"),
                ImageUrl = "https://images.unsplash.com/photo-1518180013386-746fb077171b?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjIxMTIzfQ&auto=format&fit=crop&w=1950&q=80",
                LibraryItems = _libraryItems
            };

            _libraryItems = new List<LibraryItem>()
            {
                new Book()
                {
                    Title = "On the Road",
                    Author = "Jack Kerouac",
                    Id = 1111111,
                    Year = 1959,
                    ItemStatus = new LibraryItemStatus() {Id = 2, ItemName = "On the Road", StatusDescription = "Reserved"},
                    Cost = 2.50m,
                    ImageUrl = "https://images.unsplash.com/photo-1519817914152-22d216bb9170?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1001&q=80",
                    NumberOfCopies = 2,
                    Location = _stroudBranch,
                    ISBN = "123456789"
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