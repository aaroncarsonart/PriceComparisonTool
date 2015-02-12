using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PriceComparisonTool.Models;

namespace PriceComparisonTool.Models
{
    public class ListPriority
    {
        public static readonly String MANUAL = "Manual";
        public static readonly String BEST_PRICE = "Best Price";
        public static readonly String LESS_TRIPS = "Less Trips";

        public int ListPriorityID { get; set; }
        [Display(Name = "Priority")]
        public String Label { get; set; }

        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}