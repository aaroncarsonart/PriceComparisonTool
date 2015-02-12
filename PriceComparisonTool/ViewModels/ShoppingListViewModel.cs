using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PriceComparisonTool.Models;
using PagedList;

namespace PriceComparisonTool.ViewModels
{
    public class ShoppingListViewModel
    {
        public IEnumerable<ShoppingList> ShoppingLists { get; set; }
        public PagedList<ListItem> ListItems { get; set; }
    }
}