using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using LibraryData.Models;
using LibraryData.Models.Common;
using LibraryData.Models.LibraryItems;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class LibraryItemService : ILibraryItemService
    {
        private LibraryContext _libraryContext { get; set; }

        public LibraryItemService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        //public LibraryItemService()
        //{
        //    _libraryContext = new LibraryContext(options => options.)
        //}

        public void AddItem(LibraryItem newLibraryItem)
        {
            // EF Core does all the heavy lifting for you! Add something new to the DB
            _libraryContext.Add(newLibraryItem);
            // save DB changes
            _libraryContext.SaveChanges();
        }

        // FIX THIS 
        public IEnumerable<LibraryItem> GetAllItems()
        {
            return _libraryContext.LibraryItems;
                //.Include(i => i.ItemStatus)
                //.Include(i => i.Location);
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
            var isBook = _libraryContext.LibraryItems.OfType<Book>().Where(b => b.Id.Equals(id)).Any();

            return isBook? _libraryContext.Books.Where(b => b.Id.Equals(id)).FirstOrDefault().ISBN :
                "Could't find that ISBN sorry!";
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

        // refactor
        public string GetItemType(int id)
        {
            var allItems = _libraryContext.LibraryItems;
            var book = allItems.OfType<Book>().Where(b => b.Id.Equals(id));
            var video = allItems.OfType<Video>().Where(v => v.Id.Equals(id));
            var cd = allItems.OfType<Cd>().Where(c => c.Id.Equals(id));
            var magazine = allItems.OfType<Magazine>().Where(m => m.Id.Equals(id));

            var response = "";

            if (book.Any())
            {
                response = "Book";
            }
            else if (video.Any())
            {
                response = "Video";
            }
            else if (cd.Any())
            {
                response = "CD";
            }
            else
            {
                response = "Magazine";
            }
            return response;
        }

        public string GetTitle(int id)
        {
            return _libraryContext.LibraryItems
                .Where(i => i.Id.Equals(id))
                .FirstOrDefault()
                .Title;      
        }

        // to-do: refactor
        public string GetAuthorDirectorOrArtist(int id)
        {
            // can I have these as properties so as to stop repeating them?
            var isBook = _libraryContext.LibraryItems.OfType<Book>().Where(b => b.Id.Equals(id)).Any();
            var isVideo = _libraryContext.LibraryItems.OfType<Video>().Where(v => v.Id.Equals(id)).Any();
            var isCd = _libraryContext.LibraryItems.OfType<Cd>().Where(c => c.Id.Equals(id)).Any();

            var response = "";

            if (isBook)
            {
                response = _libraryContext.Books
                    .Where(b => b.Id.Equals(id))
                    .FirstOrDefault()
                    .Author;
            }
            else if (isVideo)
            {
                response = _libraryContext.Videos
                    .Where(v => v.Id.Equals(id))
                    .FirstOrDefault()
                    .Director;
            }
            else if (isCd)
            {
                response = _libraryContext.Cds
                    .Where(v => v.Id.Equals(id))
                    .FirstOrDefault()
                    .Artist;
            }
            else
            {
                response = "Could't find that author/director/artist sorry!";
            }

            return response;
        }

        
        // to-do: add genre to LibraryItem model
        public string GetGenreOrTopic(int id)
        {
            var isVideo = _libraryContext.LibraryItems.OfType<Video>().Where(v => v.Id.Equals(id)).Any();
            var isCd = _libraryContext.LibraryItems.OfType<Cd>().Where(c => c.Id.Equals(id)).Any();
            var isMagazine = _libraryContext.LibraryItems.OfType<Magazine>().Where(m => m.Id.Equals(id)).Any();

            var response = "";

            if (isCd)
            {
                response = _libraryContext.Cds
                    .Where(c => c.Id.Equals(id))
                    .FirstOrDefault()
                    .MusicGenre;
            }
            else if(isVideo)
            {
                response = _libraryContext.Videos
                    .Where(v => v.Id.Equals(id))
                    .FirstOrDefault()
                    .FilmGenre;
            }
            else if (isMagazine)
            {
                response = _libraryContext.Magazines
                    .Where(m => m.Id.Equals(id))
                    .FirstOrDefault()
                    .Topic;
            }
            else
            {
                response = "Couldn't find that genre or topic soz!";
            }

            return response;
        }

        
    }
}
