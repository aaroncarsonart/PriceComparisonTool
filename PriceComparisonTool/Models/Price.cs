using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PriceComparisonTool.Models
{
	public class Price
	{
        [Key]
		public int PriceID { get; set; }

        [DataType(DataType.Currency)]
        [Required, Display(Name="Price")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Price cannot be zero.")]
        public decimal Value { get; set; }
		public int ProductID { get; set; }
		public int StoreID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Entry Date")]
		public DateTime Date { get; set; }


        [Display(Name = "Unit Price")]
        public String LabeledUnitPrice
        {
            get { return String.Format("{0:$#,##0.00}", UnitPrice) + " per " + this.Product.Units; }
        }

        
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString="{0:$#,##0.00}")]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice
        {
            get
            {
                if (Product != null) return Value / Product.Amount;
                else return Value;
            }
        }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
	}
}