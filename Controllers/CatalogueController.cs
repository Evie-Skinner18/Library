using LibraryData.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CatalogueController : Controller
    {
        // this controller depends on an abstraction!
        public CatalogueController(IBorrowable borrowable)
        {

        }
    }
}
