using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using LibraryData;
using LibraryData.Models;
using LibraryData.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class LibraryItemService : IBorrowable
    {
        private LibraryContext _libraryContext { get; set; }

        public LibraryItemService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public void AddItem(LibraryItem newLibraryItem)
        {
            // EF Core does all the heavy lifting for you! Add something new to the DB
            _libraryContext.Add(newLibraryItem);
            // save DB changes
            _libraryContext.SaveChanges();
        }

        public IEnumerable<LibraryItem> GetAllItems()
        {
            return _libraryContext.LibraryItems
                .Include(i => i.ItemStatus)
                .Include(i => i.Location);
        }

        public LibraryItem GetItemById(int id)
        {
            return _libraryContext.LibraryItems
                .Include(i => i.ItemStatus)
                .Include(i => i.Location)
                .Where(i => i.Id.Equals(id))
                .FirstOrDefault();
        }

        public string GetIsbn(int id)
        {
            var isBook = _libraryContext.Books.Any(b => b.Id.Equals(id));
            var response = "";

            if (isBook)
            {
                response = _libraryContext.Books
                    .Where(b => b.Id.Equals(id))
                    .FirstOrDefault()
                    .ISBN;
            }
            else
            {
                response = "Could't find that ISBN sorry!";
            }

            return response;
        }

        public LibraryBranch GetItemLocation(int id)
        {
            return _libraryContext.LibraryBranches
                .Include(b => b.Name)
                .Include(b => b.Address)
                .Include(b => b.ImageUrl)
                .Where(b => b.Id.Equals(id))
                .FirstOrDefault();
        }

        public string GetItemType(int id)
        {
            return _libraryContext.LibraryItems
                .Where(i => i.Id.Equals(id))
                .FirstOrDefault()
                .GetType().Name;
        }

        public string GetTitle(int id)
        {
            return _libraryContext.LibraryItems
                .Where(i => i.Id.Equals(id))
                .FirstOrDefault()
                .Title;      
        }

        public string GetAuthor(int id)
        {
            var isBook = _libraryContext.Books.Any(b => b.Id.Equals(id));
            var response = "";

            if (isBook)
            {
                response = _libraryContext.Books
                    .Where(b => b.Id.Equals(id))
                    .FirstOrDefault()
                    .Author;
            }
            else
            {
                response = "Could't find that author sorry!";
            }

            return response;
        }

        public string GetDirector(int id)
        {
            var isVideo = _libraryContext.Videos.Any(v => v.Id.Equals(id));
            var response = "";

            if (isVideo)
            {
                response = _libraryContext.Videos
                    .Where(v => v.Id.Equals(id))
                    .FirstOrDefault()
                    .Director;
            }
            else
            {
                response = "Could't find that director sorry!";
            }

            return response;
        }

        public string GetCdGenre(int id)
        {
            var isCd = _libraryContext.Cds.Any(c => c.Id.Equals(id));
            var response = "";

            if (isCd)
            {
                response = _libraryContext.Cds
                    .Where(c => c.Id.Equals(id))
                    .FirstOrDefault()
                    .MusicGenre;
            }
            else
            {
                response = "Could't find that CD genre sorry!";
            }

            return response;
        }

        public string GetMagazineTopic(int id)
        {
            var isMagazine = _libraryContext.Magazines.Any(m => m.Id.Equals(id));
            var response = "";

            if (isMagazine)
            {
                response = _libraryContext.Magazines
                    .Where(m => m.Id.Equals(id))
                    .FirstOrDefault()
                    .Topic;
            }
            else
            {
                response = "Could't find that mag topic sorry!";
            }

            return response;
        }

        public string GetFilmGenre(int id)
        {
            var isVideo = _libraryContext.Videos.Any(v => v.Id.Equals(id));
            var response = "";

            if (isVideo)
            {
                response = _libraryContext.Videos
                    .Where(v => v.Id.Equals(id))
                    .FirstOrDefault()
                    .FilmGenre;
            }
            else
            {
                response = "Could't find that film genre sorry!";
            }

            return response;
        }
    }
}
