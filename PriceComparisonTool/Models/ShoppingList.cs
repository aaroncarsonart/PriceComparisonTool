using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PriceComparisonTool.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonTool.Models
{

    public class ShoppingList
    {
        [Key]
        public int ID { get; set; }

        public String Label  { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("ListPriority")]
        public int ListPriorityID { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }
        public virtual ListPriority ListPriority { get; set; }

    }
}