using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PriceComparisonTool.Models
{
public class Store
	{
		public int ID { get; set; }

        [Required, Display(Name="Store Name"), StringLength(50, MinimumLength=1)]
		public String Name { get; set; }
		
        [DisplayFormat(DataFormatString = "{0:(###)###-####}", ApplyFormatInEditMode = true)]
        public String PhoneNumber { get; set; }
        
        public String Address { get; set; }
       
        [DataType(DataType.PostalCode)]
        public String Zipcode { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<ProductSKU> ProductSKU { get; set; }
	}
}