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

namespace PriceComparisonTool.Controllers
{
    public class ShoppingListDELETEController : Controller
    {
        private AzureContext db = new AzureContext();

        // GET: ShoppingListDELETE
        public ActionResult Index()
        {
            var shoppingLists = db.ShoppingLists.Include(s => s.ListPriority);
            return View(shoppingLists.ToList());
        }

        // GET: ShoppingListDELETE/Details/5
        public ActionResult Details(int? id)
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

        // GET: ShoppingListDELETE/Create
        public ActionResult Create()
        {
            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label");
            return View();
        }

        // POST: ShoppingListDELETE/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label", shoppingList.ListPriorityID);
            return View(shoppingList);
        }

        // GET: ShoppingListDELETE/Edit/5
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

        // POST: ShoppingListDELETE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Label,DateCreated,ListPriorityID")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListPriorityID = new SelectList(db.ListPriorities, "ListPriorityID", "Label", shoppingList.ListPriorityID);
            return View(shoppingList);
        }

        // GET: ShoppingListDELETE/Delete/5
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

        // POST: ShoppingListDELETE/Delete/5
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
