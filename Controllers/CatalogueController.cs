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
    }
}
