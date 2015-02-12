namespace PriceComparisonTool.Migrations
{
    using PriceComparisonTool.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PriceComparisonTool.DAL.AzureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public decimal RandomPrice(Random r)
        {
            return Convert.ToDecimal(r.NextDouble() + r.Next(12));
        }

        //makes  12 digit UPC
        public String MakeUPC(Random r)
        {
            return RandomNumberString(r, 12);
        }

        //make a sku of variable length, from 4 to 8 digits.
        public int MakeSKU(Random r)
        {
            return Int32.Parse(RandomNumberString(r, r.Next(5) + 3));
        }

        //makes a String of random numbers of a variable length.
        public String RandomNumberString(Random r, int length)
        {
            String s = "";

            for (int i = 0; i < length; i++)
            {
                int temp = r.Next(10);
                s += temp;
            }

            return s;
        }

        protected override void Seed(PriceComparisonTool.DAL.AzureContext context)
        {
            Random random = new Random();
            // *******************************************************************************
            // Categories
            // *******************************************************************************

            // List from: http://www.organizedtimes.com/index.php/resource-library/8-articles/19-free-grocery-shopping-list-form
            var categories = new List<Category>
            {
                // Food items
                new Category { Name = "Baby Items" },
                new Category { Name = "Baking" },
                new Category { Name = "Beverages" },
                new Category { Name = "Bread/Bakery" },
                new Category { Name = "Bulk" },
                new Category { Name = "Canned Goods" },
                new Category { Name = "Cereal/Breakfast" },
                new Category { Name = "Condiments" },
                new Category { Name = "Dairy" },
                new Category { Name = "Deli" },
                new Category { Name = "Frozen" },
                new Category { Name = "Meats" },
                new Category { Name = "Pasta/Rice" },
                new Category { Name = "Produce" },
                new Category { Name = "Snacks" },

                //non-food
                new Category { Name = "Cleaning Supplies" },
                new Category { Name = "Health and Beauty" },
                new Category { Name = "Kitchen Utensils" },
                new Category { Name = "Paper Products" },
                new Category { Name = "Pet Supplies" },
                
                //finally
                new Category { Name = "Other" },
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            // *******************************************************************************
            // Products
            // *******************************************************************************
            var products = new List<Product>
            {
                // *****************************************
                // Breakfast and Cereal
                // *****************************************
                new Product { 
                    Name = "Great Grains Crunchy Pecans",   
                    UPC = "884912126016", 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 16, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Honey Bunches of Oats",   
                    UPC = MakeUPC(random),
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 27, 
                    Units = UnitType.Ounce, 
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Great Value Oatmeal Flakes",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 18, 
                    Units = UnitType.Ounce ,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Pumpkin Flax Granola",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 10, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Kashi Go Lean",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 13, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Life - Cinnamon",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 18, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Oatmeal Squares",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 19, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Raisin Nut Bran",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 19, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Oatmeal Crisp",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 17, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Simply Granola - Quaker",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 28, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Old Fashioned Quaker Oats",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Breakfast")).ID,
                    Amount = 42, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Krave - Kelloggs",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 11, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Multi-Grain Cheerios - Dark Chocolate Crunch",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 12, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Multi-Grain Cheerios",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 18, 
                    Units = UnitType.Ounce ,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Raisin Bran Crunch",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Cereal")).ID,
                    Amount = 23, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },

                // *****************************************
                // Dairy
                // *****************************************
                new Product { 
                    Name = "Milk (Great Value)",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Dairy")).ID,
                    Amount = 1, 
                    Units = UnitType.Gallon,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Promise Butter",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Dairy")).ID,
                    Amount = 15, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Bummel and Brown Butter",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Dairy")).ID,
                    Amount = 15, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Fat Free Naturally Yours Sour Cream",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Dairy")).ID,
                    Amount = 16, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },

                // *****************************************
                // Condiments
                // *****************************************
                new Product { 
                    Name = "Heinz Ketchup (2 pk)",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Condiments")).ID,
                    Amount = 101, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Real Bacon Bits",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Condiments")).ID,
                    Amount = 3, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false
                },
                new Product { 
                    Name = "Pace Pecante Sauce (Medium)",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Condiments")).ID,
                    Amount = 24, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },


                // *****************************************
                // Bread
                // *****************************************
                new Product { 
                    Name = "Reisers Burritos",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Contains("Bread")).ID,
                    Amount = 10, 
                    Units = UnitType.Each,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },

                // *****************************************
                // Canned Goods
                // *****************************************
                new Product { 
                    Name = "Diced Tomatoes",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Canned Goods")).ID,
                    Amount = 15, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "S & W Beans",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Canned Goods")).ID,
                    Amount = 15, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },


                // *****************************************
                // Produce
                // *****************************************
                new Product { 
                    Name = "Pomegranate",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 1, 
                    Units = UnitType.Each,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Apples",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 1, 
                    Units = UnitType.Pound,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Dole Coleslaw",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 14, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Dole Iceberg Lettuce",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 12, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Sliced Mushrooms",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 8, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Baby Bellas Sliced Mushrooms",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 8, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Romaine Lettuce",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 1, 
                    Units = UnitType.Each,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Romane Lettuce Hearts",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 3, 
                    Units = UnitType.Each,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Celery Sticks",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 16, 
                    Units = UnitType.Ounce,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },
                new Product { 
                    Name = "Broccoli Crowns",   
                    UPC = MakeUPC(random), 
                    CategoryID = categories.Single(i => i.Name.Equals("Produce")).ID,
                    Amount = 1, 
                    Units = UnitType.Pound,
                    IsGMO = false,
                    IsCO = false,
                    IsLG = false 
                },


            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            // *******************************************************************************
            // ProductSKU
            // *******************************************************************************

            var productsku = new List<ProductSKU>
            {
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 33, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 33, 
                    StoreID = 2     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 33, 
                    StoreID = 3     
                },

                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 1, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 2, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 3, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 4, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 5, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 6, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 6, 
                    StoreID = 2     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 6, 
                    StoreID = 3     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 7, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 8, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 9, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 10, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 11, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 12, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 12, 
                    StoreID = 2     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 13, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 13, 
                    StoreID = 3     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 14, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 15, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 16, 
                    StoreID = 1     
                },
                new ProductSKU {
                    SKU = MakeSKU(random), 
                    ProductID = 17, 
                    StoreID = 1     
                },

            };
            context.Database.ExecuteSqlCommand("delete from ProductSKU");
            productsku.ForEach(s => context.ProductSKU.Add(s));
            context.SaveChanges();

            // *******************************************************************************
            // Stores
            // *******************************************************************************
            var stores = new List<Store>
            {
                new Store {
                    Name = "Fred Meyer", 
                    PhoneNumber = "5035857151", 
                    Address = "2855 Broadway St NE", 
                    Zipcode = "97302"
                },
                new Store {
                    Name = "Walmart", 
                    PhoneNumber = "5033625982", 
                    Address = "3025 Lancaster Dr NE", 
                    Zipcode = "97305"
                },
                new Store {
                    Name = "Winco Foods", 
                    PhoneNumber = "5033622620", 
                    Address = "4575 Commercial St Ne", 
                    Zipcode = "97302"
                }
            };
            stores.ForEach(s => context.Stores.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            // *******************************************************************************
            // Prices
            // *******************************************************************************
            var prices = new List<Price>
            {
                // *****************************************
                // Walmart
                // *****************************************
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = products.Single(
                    p => p.Name.Contains("Great Grains")
                        && p.Amount == 16
                        && p.Units == UnitType.Ounce
                    ).ID, 
                    Value = 2.88m,
                    Date = DateTime.Parse("2013-10-22")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = products.Single(
                    p => p.Name.Contains("Honey Bunches of Oats")
                        && p.Amount == 27
                        && p.Units == UnitType.Ounce
                    ).ID, 
                    Value = 3.86m,
                    Date = DateTime.Parse("2013-10-22")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = products.Single(
                    p => p.Name.Contains("Pumpkin Flax")
                        && p.Amount == 10
                        && p.Units == UnitType.Ounce
                    ).ID, 
                    Value = 2.88m,
                    Date = DateTime.Parse("2013-10-22")                      
                },

                //Price run for a product over Time
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 1,
                    Value = 2.88m,
                    Date = DateTime.Parse("2013-11-1")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 1,
                    Value = 2.88m,
                    Date = DateTime.Parse("2013-11-8")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 1,
                    Value = 3.15m,
                    Date = DateTime.Parse("2013-11-15")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 1,
                    Value = 3.25m,
                    Date = DateTime.Parse("2013-11-22")                      
                },

                //Price run for a product over time
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 2,
                    Value = 9.99m,
                    Date = DateTime.Parse("2013-11-1")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 2,
                    Value = 8.99m,
                    Date = DateTime.Parse("2013-11-8")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 2,
                    Value = 8.99m,
                    Date = DateTime.Parse("2013-11-15")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 2,
                    Value = 10.99m,
                    Date = DateTime.Parse("2013-11-22")                      
                },

                //Price run for a product over time
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 3,
                    Value = 15.99m,
                    Date = DateTime.Parse("2013-11-1")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 3,
                    Value = 15.99m,
                    Date = DateTime.Parse("2013-11-8")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 3,
                    Value = 12.99m,
                    Date = DateTime.Parse("2013-11-15")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 3,
                    Value = 9.99m,
                    Date = DateTime.Parse("2013-11-22")                      
                },

                // *****************************************
                // Fred Meyer
                // *****************************************

                //price run for 1
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 1,
                    Value = 4.0m,
                    Date = DateTime.Parse("2013-11-03")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 1,
                    Value = 3.99m,
                    Date = DateTime.Parse("2013-11-08")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 1,
                    Value = 3.99m,
                    Date = DateTime.Parse("2013-11-13")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 1,
                    Value = 3.59m,
                    Date = DateTime.Parse("2013-11-18")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 1,
                    Value = 4.29m,
                    Date = DateTime.Parse("2013-11-18")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 1,
                    Value = 4.69m,
                    Date = DateTime.Parse("2013-11-23")                      
                },

                //price run for 2
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 2,
                    Value = 5.99m,
                    Date = DateTime.Parse("2013-11-03")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 2,
                    Value = 5.99m,
                    Date = DateTime.Parse("2013-11-08")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 2,
                    Value = 6.99m,
                    Date = DateTime.Parse("2013-11-13")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 2,
                    Value = 6.79m,
                    Date = DateTime.Parse("2013-11-18")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 2,
                    Value = 7.99m,
                    Date = DateTime.Parse("2013-11-18")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 2,
                    Value = 7.99m,
                    Date = DateTime.Parse("2013-11-23")                      
                },

                //price run for 3
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 3,
                    Value = 11.99m,
                    Date = DateTime.Parse("2013-11-03")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 3,
                    Value = 11.99m,
                    Date = DateTime.Parse("2013-11-08")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 3,
                    Value = 12.99m,
                    Date = DateTime.Parse("2013-11-13")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 3,
                    Value = 12.79m,
                    Date = DateTime.Parse("2013-11-18")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 3,
                    Value = 8.99m,
                    Date = DateTime.Parse("2013-11-18")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 3,
                    Value = 8.99m,
                    Date = DateTime.Parse("2013-11-23")                      
                },

                // *****************************************
                // Winco Foods
                // *****************************************

                //price run for 1
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 1,
                    Value = 1.99m,
                    Date = DateTime.Parse("2013-11-01")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 1,
                    Value = 1.99m,
                    Date = DateTime.Parse("2013-11-15")                      
                },
                
                //price run for 2
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 2,
                    Value = 7.99m,
                    Date = DateTime.Parse("2013-11-01")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 2,
                    Value = 7.59m,
                    Date = DateTime.Parse("2013-11-15")                      
                },

                 //price run for 3
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 3,
                    Value = 9.99m,
                    Date = DateTime.Parse("2013-11-01")                      
                },
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 3,
                    Value = 11.99m,
                    Date = DateTime.Parse("2013-11-15")                      
                },
                

                //other data
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 4,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 5,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 6,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 7,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 8,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 9,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 10,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 11,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 12,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 13,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 14,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 15,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 16,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 17,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 18,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 19,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Winco Foods" ).ID, 
                    ProductID = 20,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 21,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 22,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 23,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 24,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 25,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 26,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 27,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 28,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 29,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 30,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 31,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 32,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 33,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 34,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Walmart" ).ID, 
                    ProductID = 35,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                
                // other - fred meyer
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 4,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 5,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 6,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 7,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 8,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 9,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 10,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 11,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 12,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 13,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 14,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 15,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 16,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 17,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 18,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 19,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 20,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-11")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 21,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 22,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 23,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 24,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 25,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 26,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 27,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 28,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 29,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 30,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 31,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 32,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 33,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
                new Price { 
                    StoreID = stores.Single(s => s.Name == "Fred Meyer" ).ID, 
                    ProductID = 34,
                    Value = RandomPrice(random),
                    Date = DateTime.Parse("2014-12-07")                      
                },
                 
            };

            foreach (Price e in prices)
            {
                IEnumerable<Price> priceInDb = context.Prices.Where(
                    p =>
                         p.ProductID == e.ProductID &&
                         p.StoreID == e.StoreID &&
                         p.Date == e.Date);
                if (priceInDb.Count() == 0)
                {
                    context.Prices.Add(e);
                }
            }
            context.SaveChanges();

            // *******************************************************************************
            // ListPriority
            // *******************************************************************************
            var listPriorities = new List<ListPriority>
            {
                new ListPriority {
                    Label = "Manual",
                },
                new ListPriority {
                    Label = "Best Price",
                },
                new ListPriority {
                    Label = "Less Trips",
  
                },
            };
            listPriorities.ForEach(s => context.ListPriorities.AddOrUpdate(p => p.Label, s));
            context.SaveChanges();

            // *******************************************************************************
            // ShoppingLists
            // *******************************************************************************
            var shoppingLists = new List<ShoppingList>
            {
                new ShoppingList {
                    Label = "Quick Run",
                    DateCreated = DateTime.Parse("2014.11.01"),
                    ListPriorityID = 1,
                },
                new ShoppingList {
                    Label = "Regular Grocery Trip",
                    DateCreated = DateTime.Parse("2014.11.07"),
                    ListPriorityID = 2,
                },
                new ShoppingList {
                    Label = "Preparing for Thanskgiving",
                    DateCreated = DateTime.Parse("2014.11.19"),
                    ListPriorityID = 3,
                },
            };
            shoppingLists.ForEach(s => context.ShoppingLists.AddOrUpdate(p => p.DateCreated, s));
            context.SaveChanges();

            // *******************************************************************************
            // ListItems
            // *******************************************************************************
            var listItems = new List<ListItem>
            {
                // quick run
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Quick Run").Single().ID, 
                    ProductID = 1,
                    StoreID   = 1,
                    Quantity  = 1
                },

                // Regular shopping trip
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 1,
                    StoreID   = 1,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 2,
                    StoreID   = 3,
                    Quantity  = 2
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 3,
                    StoreID   = 2,
                    Quantity  = 10
                },
                new ListItem {
                ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 4,
                    StoreID   = 1,
                    Quantity  = 5
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 5,
                    StoreID   = 3,
                    Quantity  = 10
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 6,
                    StoreID   = 3,
                    Quantity  = 10
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 7,
                    StoreID   = 3,
                    Quantity  = 10
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 17,
                    StoreID   = 2,
                    Quantity  = 2
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 18,
                    StoreID   = 2,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 19,
                    StoreID   = 2,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 20,
                    StoreID   = 2,
                    Quantity  = 3
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 21,
                    StoreID   = 2,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Regular Grocery Trip").Single().ID, 
                    ProductID = 22,
                    StoreID   = 2,
                    Quantity  = 1
                },

                // thanksgiving trip!
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Preparing for Thanskgiving").Single().ID, 
                    ProductID = 24,
                    StoreID   = 1,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Preparing for Thanskgiving").Single().ID, 
                    ProductID = 25,
                    StoreID   = 1,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Preparing for Thanskgiving").Single().ID, 
                    ProductID = 26,
                    StoreID   = 1,
                    Quantity  = 1
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Preparing for Thanskgiving").Single().ID, 
                    ProductID = 27,
                    StoreID   = 2,
                    Quantity  = 3
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Preparing for Thanskgiving").Single().ID, 
                    ProductID = 28,
                    StoreID   = 2,
                    Quantity  = 6
                },
                new ListItem {
                    ListID    = context.ShoppingLists.Where(i => i.Label == "Preparing for Thanskgiving").Single().ID, 
                    ProductID = 29,
                    StoreID   = 3,
                    Quantity  = 99
                },
                
               
            };
            context.Database.ExecuteSqlCommand("delete from ListItem");
            listItems.ForEach(s => context.ListItems.Add(s));
            context.SaveChanges();

        }
    }
}
