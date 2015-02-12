using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PriceComparisonTool.DAL;
using PriceComparisonTool.Models;
using PriceComparisonTool.ViewModels;
using PagedList;

namespace PriceComparisonTool.Controllers
{
    public class ShoppingListController : Controller
    {
        private AzureContext db = new AzureContext();

        // GET: ShoppingList
        public ActionResult Index(int? id, int? listItemPage)
        {
            var viewModel = new ShoppingListViewModel();
            viewModel.ShoppingLists = db.ShoppingLists
                .Include(s => s.ListPriority)
                .OrderBy(i => i.DateCreated).ToList();
            if (id != null)
            {
                ViewBag.ListID = id.Value;
                viewModel.ListItems = (PagedList<ListItem>)viewModel.ShoppingLists
                    .Where(i => i.ID == id.Value).Single()
                    .ListItems.OrderBy(i => i.StoreID)
                    .ThenBy(i => i.Product.CategoryID)
                    .ThenBy(i => i.Product.Name)
                    .ToPagedList(listItemPage ?? 1, 5);
            }
            return View(viewModel);
        }


        // GET: ShoppingList/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListDetailsViewModel detailsModel = new ShoppingListDetailsViewModel();
            detailsModel.ShoppingList = db.ShoppingLists.Find(id);
            detailsModel.ListItems = detailsModel.ShoppingList.ListItems
                .OrderBy(i => i.StoreID)
                .ThenBy(i => i.Product.CategoryID)
                .ThenBy(i => i.Product.Name);
            if (detailsModel == null)
            {
                return HttpNotFound();
            }
            return View(detailsModel);
        }

        // updates this ShoppingList's Listitems according to the current ListPriority.
        // If set to "Manual", then no changes will occur.
        public void SortShoppingListItems(int listID)
        {
            //System.Diagnostics.Debug.WriteLine("!!! shoppingList == null:" + (shoppingList == null));
            //System.Diagnostics.Debug.WriteLine("!!! shoppingList.ListItems == null:" + (shoppingList.ListItems == null));
            //shoppingList.ListItems = db.ListItems.Where(i => i.ListID == shoppingList.ID).ToList();
            //System.Diagnostics.Debug.WriteLine("!!! shoppingList.ListItems == null:" + (shoppingList.ListItems == null));

            ShoppingList shoppingList = db.ShoppingLists
                .Include(i => i.ListItems)
                .Include(i => i.ListPriority)
                .Where(i => i.ID == listID)
                .Single();

           

            // **************************************************************************
            // CASE 1: Best Price Sorting
            // **************************************************************************
            if (shoppingList.ListPriority.Label == ListPriority.BEST_PRICE)
            {
                foreach (ListItem l in shoppingList.ListItems)
                {
                    // (use HashSet to quickly resolve duplicates)
                    HashSet<Store> stores = new HashSet<Store>();
                    foreach (Price r in l.Product.Prices)
                    {
                        System.Diagnostics.Debug.WriteLine("***********************************");
                        System.Diagnostics.Debug.WriteLine("!!! 1) foreach Price.value: " +r.Value);
                        System.Diagnostics.Debug.WriteLine("***********************************");
                        stores.Add(r.Store);
                    }

                    // add the recent price entry for each store
                    List<Price> prices = new List<Price>();
                    foreach (Store s in stores)
                    {
                        System.Diagnostics.Debug.WriteLine("***********************************");
                        System.Diagnostics.Debug.WriteLine("!!! 2) foreach Store.name: " + s.Name);
                        System.Diagnostics.Debug.WriteLine("***********************************");
                        prices.Add(s.Prices
                            .OrderByDescending(i => i.Date)
                            .FirstOrDefault());
                    }
                    System.Diagnostics.Debug.WriteLine("***********************************");
                    System.Diagnostics.Debug.WriteLine("l.Product.Name:        " + l.Product.Name);
                    System.Diagnostics.Debug.WriteLine("l.Product.Prices.size: " + l.Product.Prices.Count());
                    System.Diagnostics.Debug.WriteLine("prices.size:           " + prices.Count());
                    System.Diagnostics.Debug.WriteLine("***********************************");
                    Price bestPrice = prices.OrderBy(i => i.Value).FirstOrDefault();
                    if (bestPrice == null)
                    {
                        l.StoreID = db.Stores.FirstOrDefault().ID;
                    }
                    else
                    {
                        // update the StoreID values
                        l.StoreID = bestPrice.StoreID;
                    }
                    db.Entry(l).State = EntityState.Modified;
                }
            }






            // **************************************************************************
            // CASE 2: Less Trips Sorting
            // **************************************************************************
            else if (shoppingList.ListPriority.Label == ListPriority.LESS_TRIPS)
            {
                //get all stores available to the list.
                HashSet<Store> stores = new HashSet<Store>();
                foreach (ListItem l in shoppingList.ListItems)
                {
                    List<Price> tempPrices = db.Prices.Where(i => i.ProductID == l.ProductID).ToList();
                    foreach(Price p in tempPrices)
                    {
                        stores.Add(p.Store);
                    }
                }

                //get all products in this list.
                HashSet<Product> products = new HashSet<Product>();
                foreach (ListItem l in shoppingList.ListItems)
                {
                    products.Add(l.Product);
                }

               
                // a list of products for each store
                List<HashSet<Product>> productLists = new List<HashSet<Product>>();
               
                // iterate over each Store!!!!
                foreach(Store s in stores)
                {
                    List<Price> storePrices = db.Prices
                        .Include(i => i.Store)
                        .Include(i => i.Product)
                        .Where(i => i.StoreID == s.ID).ToList();

                   HashSet<Product> currentProducts = new HashSet<Product>();
                    
                    foreach(Price r in storePrices) {
                        if (products.Contains(r.Product)) {
                            currentProducts.Add(r.Product);
                        }
                    }
                    productLists.Add(currentProducts);
                }

                //order the list of Hashsets by Descending order of size
                productLists.OrderByDescending(i => i.Count);

                //populate the store in succession 
                for (int i = 0; i < stores.Count; i++)
                {
                   foreach(Product p in productLists.ElementAt(i))
                    {
                        if (products.Contains(p))
                        {
                            List<ListItem> items = shoppingList.ListItems
                               .Where(j => j.ProductID == p.ID).ToList();
                            foreach(ListItem l in items){
                                l.StoreID = stores.ElementAt(i).ID;
                                db.Entry(l).State = EntityState.Modified;
                            }
                            products.Remove(p);
                            
                        }
                    }
                }
            }
            // **************************************************************************
            // CASE 3: Manual Sorting (do nothing to ListItem Data
            // **************************************************************************
            // Done!
            // db.SaveChanges();
        }

        // GET: ShoppingList/AddEntry
        public ActionResult AddEntry(int listID)
        {
            CreateListItemViewModel viewModel = new CreateListItemViewModel();
            viewModel.ShoppingList = db.ShoppingLists.Find(listID);
            viewModel.ListItems = viewModel.ShoppingList.ListItems
                .OrderBy(i => i.StoreID)
                .ThenBy(i => i.Product.CategoryID)
                .ThenBy(i => i.Product.Name);
            viewModel.ProductID = new SelectList(db.Products, "ID", "Name");
            viewModel.ListID = new SelectList(db.ShoppingLists, "ID", "Label");
            viewModel.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View(viewModel);
        }

        // POST: ListItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEntry([Bind(Include = "ItemID,ListID,ProductID,StoreID,Quantity")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                db.ListItems.Add(listItem);
                db.SaveChanges();
                return RedirectToAction("Index", "ShoppingList", new { id=1, listItemPage = 1 });
            }

            CreateListItemViewModel viewModel = new CreateListItemViewModel();

            viewModel.NewListItem = listItem;
            viewModel.ProductID = new SelectList(db.Products, "ID", "Name");
            viewModel.ListID = new SelectList(db.ShoppingLists, "ID", "Label");
            viewModel.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View(viewModel);
        }

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label");
            return View();
        }

        // POST: ShoppingList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Label,DateCreated,ListPriorityID")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingLists.Add(shoppingList);
                db.SaveChanges();
                return RedirectToAction("Index", "ShoppingList", new {listID = shoppingList.ID});
            }

            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label", shoppingList.ListPriorityID);
            return View(shoppingList);
        }

        // GET: ShoppingList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label", shoppingList.ListPriorityID);
            return View(shoppingList);
        }

        // POST: ShoppingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Label,DateCreated,ListPriorityID")] ShoppingList shoppingList)
        {
            // sort the list items!!!
            if (ModelState.IsValid)
            {
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();

                SortShoppingListItems(shoppingList.ID);
                db.SaveChanges();
            

                return RedirectToAction("Index");
            }
            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label", shoppingList.ListPriorityID);
            return View(shoppingList);
        }

        // GET: ShoppingList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            db.ShoppingLists.Remove(shoppingList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
