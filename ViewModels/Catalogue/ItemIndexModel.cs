using System.Collections.Generic;

namespace Library.ViewModels.Catalogue
{
    // we ahve page model for every page and component model for every component, to keep things modular
    public class ItemIndexModel
    {
        public IEnumerable<ItemIndexListingModel> Items { get; set; }
    }
}
