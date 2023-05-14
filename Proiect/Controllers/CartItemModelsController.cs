using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Proiect.Controllers
{
    public class CartItemModelsController : Controller
    {
        private WebsiteContext db = new WebsiteContext();

        // GET: CartItemModels
        public ActionResult Index()
        {
            return View(db.CartItems.ToList());
        }

        // GET: CartItemModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItemModel cartItemModel = db.CartItems.Find(id);
            if (cartItemModel == null)
            {
                return HttpNotFound();
            }
            return View(cartItemModel);
        }

        // GET: CartItemModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartItemModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartItemId,ProductId,CartId,Quantity")] CartItemModel cartItemModel)
        {
            if (ModelState.IsValid)
            {
                db.CartItems.Add(cartItemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cartItemModel);
        }

        // GET: CartItemModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItemModel cartItemModel = db.CartItems.Find(id);
            if (cartItemModel == null)
            {
                return HttpNotFound();
            }
            return View(cartItemModel);
        }

        // POST: CartItemModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartItemId,ProductId,CartId,Quantity")] CartItemModel cartItemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartItemModel);
        }

        // GET: CartItemModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItemModel cartItemModel = db.CartItems.Find(id);
            if (cartItemModel == null)
            {
                return HttpNotFound();
            }
            return View(cartItemModel);
        }

        // POST: CartItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartItemModel cartItemModel = db.CartItems.Find(id);
            db.CartItems.Remove(cartItemModel);
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
