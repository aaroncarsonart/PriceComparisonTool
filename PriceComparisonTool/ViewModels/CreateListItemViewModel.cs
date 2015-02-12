using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using PriceComparisonTool.Models;

namespace PriceComparisonTool.ViewModels
{
    public class CreateListItemViewModel
    {
        public SelectList ProductID { get; set; }
        public SelectList ListID { get; set; }
        public SelectList StoreID { get; set; }

        public ListItem NewListItem { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public IEnumerable<ListItem> ListItems { get; set; }
    }
}