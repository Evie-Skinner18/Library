using System.Linq;
using Library.ViewModels.Catalogue;
using LibraryData.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CatalogueController : Controller
    {
        private ILibraryItemService _itemService;

        // this controller depends on an abstraction!
        public CatalogueController(ILibraryItemService itemService)
        {
            _itemService = itemService;
        }

        // root route/catalogue
        public IActionResult Index()
        {
            var allItems = _itemService.GetAllItems().ToList();
            // map each library item into an equivalent item but the View Model versoin.
            // can't I do this with auto mapper??
            var allViewItems = allItems
                .Select(i => new ItemIndexListingModel
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    AuthorOrDirector = _itemService.GetAuthorDirectorOrArtist(i.Id),
                    NumberOfCopies = i.NumberOfCopies,
                    Title = i.Title,
                    Type = _itemService.GetItemType(i.Id)
                });

            var itemIndexModel = new ItemIndexModel()
            {
                Items = allViewItems
            };

            return View(itemIndexModel);
        }
    }
}