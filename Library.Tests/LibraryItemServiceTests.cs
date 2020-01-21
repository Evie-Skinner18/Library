using System;
using System.Collections.Generic;
using Library.Data;
using LibraryData.Models;
using LibraryData.Models.Common;
using LibraryData.Models.LibraryItems;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Library.Tests
{
    public class LibraryItemServiceTests
	{
		private ILibraryItemService _fakeLibraryService;
		private LibraryContext _libraryContext;
		private LibraryBranch _stroudBranch;
		private IEnumerable<LibraryItem> _libraryItems;
		private DbSet<LibraryItem> _setOfItems;


		[SetUp]
		public void Setup()
		{
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
					ItemStatus = new LibraryItemStatus() {Id = 1, ItemName = "On the Road", StatusDescription = "Reserved"},
					Cost = 2.50m,
					ImageUrl = "https://images.unsplash.com/photo-1519817914152-22d216bb9170?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1001&q=80",
					NumberOfCopies = 2,
					Location = _stroudBranch,
					ISBN = "123456789"
				},
				new Cd()
				{
					Title = "More Fyah",
					Artist = "Eva Lazarus and Mungo's Hifi",
					Id = 22222,
					Year = 2019,
					ItemStatus = new LibraryItemStatus() {Id = 2, ItemName = "More Fyah", StatusDescription = "Available"},
					Cost = 1.50m,
					ImageUrl = "https://images.unsplash.com/photo-1517594422361-5eeb8ae275a9?ixlib=rb-1.2.1&auto=format&fit=crop&w=1950&q=80",
					NumberOfCopies = 5,
					Location = _stroudBranch,
					MusicGenre = "Reggae"
				},
				new Video()
				{
					Title = "The Karate Kid",
					Director = "John G. Avildsen",
					Id = 3333,
					Year = 1984,
					ItemStatus = new LibraryItemStatus() {Id = 3, ItemName = "The Karate Kid", StatusDescription = "Available"},
					Cost = 3.50m,
					ImageUrl = "https://images.unsplash.com/photo-1555597673-b21d5c935865?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1952&q=80",
					NumberOfCopies = 1,
					Location = _stroudBranch,
					FilmGenre = "Action"
				},
				new Magazine()
				{
					Title = "Rhythm",
					HasCollectibleInside = true,
					Id = 4444,
					Year = 2018,
					ItemStatus = new LibraryItemStatus() {Id = 4, ItemName = "Rhythm", StatusDescription = "On loan"},
					Cost = 0.50m,
					ImageUrl = "https://images.unsplash.com/photo-1519892300165-cb5542fb47c7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1950&q=80",
					NumberOfCopies = 10,
					Location = _stroudBranch,
					Topic = "Music"
				}
			};

			_fakeLibraryService = new FakeLibraryItemService(_libraryContext);

		}

		[Test]
		public void CanGetAllLibraryItems_ShouldReturnIEnumerableOfAllLibraryItems()
		{
			var allItems = _fakeLibraryService.GetAllItems();

			Assert.That(allItems, Is.Not.Null);
		}
	}
}
