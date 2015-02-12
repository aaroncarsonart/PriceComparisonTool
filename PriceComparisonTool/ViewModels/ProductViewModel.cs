using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PriceComparisonTool.Models;
using PagedList;

namespace PriceComparisonTool.ViewModels
{
    public class ProductViewModel
    {
        
        public PagedList<Product> Products { get; set; }
        public IEnumerable<Price> Prices { get; set; }
        public IEnumerable<ProductSKU> ProductSKU { get; set; }

    }
}