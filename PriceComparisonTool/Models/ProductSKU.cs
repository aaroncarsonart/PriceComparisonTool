using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PriceComparisonTool.Models
{
    public class ProductSKU
    {
        [Key]
        public int ID { get; set; }
        public int SKU { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Store")]
        public int StoreID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}