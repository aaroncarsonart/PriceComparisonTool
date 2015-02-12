using System;
using System.Collections.Generic;
using PriceComparisonTool.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PriceComparisonTool.DAL
{
    public class AzureContext : DbContext
    {

        public AzureContext()
            : base("AzureContext")
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Price> Prices { get; set; }
  
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductSKU> ProductSKU { get; set; }
        public DbSet<ListPriority> ListPriorities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Category>().MapToStoredProcedures();
        }
    }
}