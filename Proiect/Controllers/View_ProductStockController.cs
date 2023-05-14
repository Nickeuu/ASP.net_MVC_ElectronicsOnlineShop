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
    public class View_ProductStockController : Controller
    {
        private WebsiteContext db = new WebsiteContext();

        // GET: View_ProductStock
        public ActionResult Index()
        {
            return View(db.View_ProductStock.ToList());
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
