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
        public ActionResult Index(string p)
        {
            var values = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x=>x.MUSTERIAD.Contains(p));
            }
            return View(values.ToList());
            //var values = db.TBLMUSTERILER.ToList();
            //return View(values);
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(TBLMUSTERILER model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCustomer");
            }
            db.TBLMUSTERILER.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetByIdCustomer(int id)
        {
            var value = db.TBLMUSTERILER.Find(id);
            return View("GetByIdCustomer", value);
        }
        public ActionResult Update(TBLMUSTERILER model)
        {
            var value = db.TBLMUSTERILER.Find(model.MUSTERIID);
            value.MUSTERIAD = model.MUSTERIAD;
            value.MUSTERISOYAD = model.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}