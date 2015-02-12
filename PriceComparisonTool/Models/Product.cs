using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonTool.Models
{
    public enum UnitType
    {
        Each, Pound, Ounce, Fluid_Ounce, Liter, Gallon
    }

	public class Product

	{
        [Key]
		public int ID { get; set; }
        
        [StringLength(50, MinimumLength = 1)]
        public String Name { get; set; }

        [RegularExpression(@"^[0-9]{0,12}$")]
        public String UPC { get; set; }

        public int CategoryID { get; set; }
        [Range(0, 500)]
        public int Amount { get; set; }
        public UnitType Units{ get; set; }

        [Display(Name = "Amount")]
        
        public string AmountInUnits
        {
            get { return Amount + " " + Units; }
        }
        public bool IsGMO { get; set; }
        public bool IsCO { get; set; }
        public bool IsLG { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<ProductSKU> ProductSKU { get; set; }
	}
}