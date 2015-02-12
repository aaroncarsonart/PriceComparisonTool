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
    public class ProductSKUController : Controller
    {
        private AzureContext db = new AzureContext();

        // GET: ProductSKU
        public ActionResult Index()
        {
            var productSKU = db.ProductSKU.Include(p => p.Product).Include(p => p.Store);
            return View(productSKU.ToList());
        }

        // GET: ProductSKU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSKU productSKU = db.ProductSKU.Find(id);
            if (productSKU == null)
            {
                return HttpNotFound();
            }
            return View(productSKU);
        }

        // GET: ProductSKU/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: ProductSKU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SKU,ProductID,StoreID")] ProductSKU productSKU)
        {
            if (ModelState.IsValid)
            {
                db.ProductSKU.Add(productSKU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productSKU.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", productSKU.StoreID);
            return View(productSKU);
        }

        // GET: ProductSKU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSKU productSKU = db.ProductSKU.Find(id);
            if (productSKU == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productSKU.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", productSKU.StoreID);
            return View(productSKU);
        }

        // POST: ProductSKU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SKU,ProductID,StoreID")] ProductSKU productSKU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSKU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", productSKU.ProductID);
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", productSKU.StoreID);
            return View(productSKU);
        }

        // GET: ProductSKU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSKU productSKU = db.ProductSKU.Find(id);
            if (productSKU == null)
            {
                return HttpNotFound();
            }
            return View(productSKU);
        }

        // POST: ProductSKU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSKU productSKU = db.ProductSKU.Find(id);
            db.ProductSKU.Remove(productSKU);
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
