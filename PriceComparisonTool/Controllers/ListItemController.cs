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
using PagedList;
using System.Data.Entity.Infrastructure;

namespace PriceComparisonTool.Controllers
{
    public class ListItemController : Controller
    {
        private AzureContext db = new AzureContext();

        // GET: ListItem
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            var listItems = db.ListItems.Include(l => l.Product).Include(l => l.ShoppingList).Include(l => l.Store);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SortParm = sortOrder == "List" ? "list_desc" : "List";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;


            if (!String.IsNullOrEmpty(searchString))
            {
                listItems = listItems.Where(s => s.Product.Name.Contains(searchString)
                                       || s.Product.Category.Name.Contains(searchString)
                                       || s.Store.Name.Contains(searchString)
                                       || s.ShoppingList.Label.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listItems = listItems.OrderByDescending(s => s.Store.Name);
                    break;
                case "List":
                    listItems = listItems.OrderBy(s => s.ShoppingList.Label);
                    break;
                case "list_desc":
                    listItems = listItems.OrderByDescending(s => s.ShoppingList.Label);
                    break;
                default:
                    listItems = listItems.OrderBy(s => s.Store.Name);
                    break;
            }
            return View(listItems.ToList());
        }

        // GET: ListItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ListItem listItem = db.ListItems.Find(id);
            string query = "SELECT * FROM ListItem WHERE ItemID = @p0";
            ListItem listItem = db.ListItems.SqlQuery(query, id).SingleOrDefault();
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return View(listItem);
        }

        // GET: ListItem/Create
        public ActionResult Create(int? id)
        {
            if (id == null) id = 1;
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            ViewBag.ListID = new SelectList(db.ShoppingLists, "ID", "Label", db.ShoppingLists.Find(id));
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: ListItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ListID,ProductID,StoreID,Quantity")] ListItem listItem)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.ListItems.Add(listItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", listItem.ProductID);
            ViewBag.ListID = new SelectList(db.ShoppingLists, "ID", "Label", listItem.ListID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", listItem.StoreID);
            return View(listItem);
        }

        // GET: ListItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", listItem.ProductID);
            ViewBag.ListID = new SelectList(db.ShoppingLists, "ID", "Label", listItem.ListID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", listItem.StoreID);
            return View(listItem);
        }

        // POST: ListItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ListID,ProductID,StoreID,Quantity")] ListItem listItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(listItem).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", listItem.ProductID);
            ViewBag.ListID = new SelectList(db.ShoppingLists, "ID", "Label", listItem.ListID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", listItem.StoreID);
            return View(listItem);
        }

        // GET: ListItem/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return View(listItem);
        }

        // POST: ListItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                ListItem listItem = db.ListItems.Find(id);
                db.ListItems.Remove(listItem);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

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
