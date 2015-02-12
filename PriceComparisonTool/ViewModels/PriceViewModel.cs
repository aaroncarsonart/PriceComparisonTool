using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PriceComparisonTool.Models;
using System.ComponentModel.DataAnnotations;

namespace PriceComparisonTool.ViewModels
{
    public class PriceViewModel
    {
        public int PriceID { get; set; }
        public String StoreName { get; set; }
        public String ProductName { get; set; }
        public String FormattedAmount { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}