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
    public class CartModelsController : Controller
    {
        private WebsiteContext db = new WebsiteContext();

        // GET: CartModels
        public ActionResult Index()
        {
            return View(db.Cart.ToList());
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
