using MvsStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvsStok.Controllers
{
    public class CustomerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.TBLMUSTERILER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(TBLMUSTERILER model)
        {
            db.TBLMUSTERILER.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}