using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Proiect.Models;
using Test1.Controllers;

namespace Proiect.Controllers
{
    
    public static class CurrentUser
    {
        public static int Id { get; set; } = 0;
    }
    
    public class AccountModelsController : Controller
    {
        private DataLibrary.DataAccess.WebsiteContext db = new DataLibrary.DataAccess.WebsiteContext();

        // GET: AccountModels
        public ActionResult Index()
        {
            return View(db.Account.ToList());
        }

        // GET: AccountModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel accountModel = db.Account.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        // GET: AccountModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,FirstName,MiddleName,LastName,Password,Email")] AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                db.Account.Add(accountModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountModel);
        }

        // GET: AccountModels/LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        // POST: AccountModels/LogIn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn([Bind(Include = "Password,Email")] LogInModel logInModel)
        {
            var HomeController = new HomeController();
            if (ModelState.IsValid)
            {
                var myModelId = from b in db.Account
                              where b.Email == logInModel.Email && b.Password == logInModel.Password
                              select b.AccountId.ToString();
                CurrentUser.Id = myModelId.AsQueryable().Cast<int>().FirstOrDefault();



                if (CurrentUser.Id != 0)
                {
                    ViewBag.Message = "Logged In!";
                }
                else
                {
                    CurrentUser.Id = 0;
                    ViewBag.Message = "Wrong password or email!";
                }
            }
            
            return View(logInModel);
        }

        // GET: AccountModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel accountModel = db.Account.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        // POST: AccountModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,FirstName,MiddleName,LastName,Password,Email")] AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountModel);
        }

        // GET: AccountModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel accountModel = db.Account.Find(id);
            if (accountModel == null)
            {
                return HttpNotFound();
            }
            return View(accountModel);
        }

        // POST: AccountModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountModel accountModel = db.Account.Find(id);
            db.Account.Remove(accountModel);
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
