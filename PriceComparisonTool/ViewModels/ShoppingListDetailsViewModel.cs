using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PriceComparisonTool.Models;

namespace PriceComparisonTool.ViewModels
{
    public class ShoppingListDetailsViewModel
    {
        public ShoppingList ShoppingList { get; set; }
        public IEnumerable<ListItem> ListItems { get; set; }
    }
}