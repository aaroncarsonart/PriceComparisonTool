using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonTool.Models
{
    public class ListItem
    {
        [Key]
        public int ItemID { get; set; }

        [Required, ForeignKey("ShoppingList")]
        public int ListID { get; set; }

        //[Required, ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required, ForeignKey("Store")]
        public int StoreID { get; set; }

        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}