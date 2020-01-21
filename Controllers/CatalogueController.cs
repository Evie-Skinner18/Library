using System.Linq;
using Library.ViewModels.Catalogue;
using LibraryData.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CatalogueController : Controller
    {
        private IBorrowable _borrowable;

        // this controller depends on an abstraction!
        public CatalogueController(IBorrowable borrowable)
        {
            _borrowable = borrowable;
        }

        // root route/catalogue
        public IActionResult Index()
        {
            var allItems = _borrowable.GetAllItems().ToList();
            var firstItem = allItems[0];
            // map each library item into an equivalent item but the View Model versoin.
            // can't I do this with auto mapper??
            var allViewItems = allItems
                .Select(i => new ItemIndexListingModel
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    AuthorOrDirector = _borrowable.GetAuthorDirectorOrArtist(i.Id),
                    NumberOfCopies = i.NumberOfCopies,
                    Title = i.Title,
                    Type = _borrowable.GetItemType(i.Id)
                });

            var itemIndexModel = new ItemIndexModel()
            {
                Items = allViewItems
            };

            return View(itemIndexModel);
        }
    }
}