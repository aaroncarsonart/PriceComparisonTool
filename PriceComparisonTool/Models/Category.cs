using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonTool.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Category")]
        public String Name { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}