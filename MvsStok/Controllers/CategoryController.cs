using MvsStok.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvsStok.Controllers
{
    public class CategoryController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int page=1)
        {
            //var degerler = db.TBLKATEGORILER.ToList();
            var values = db.TBLKATEGORILER.ToList().ToPagedList(page,4);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TBLKATEGORILER model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory");
            }
            db.TBLKATEGORILER.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetByIdCategory(int id)
        {
            var value = db.TBLKATEGORILER.Find(id);
            return View("GetByIdCategory",value);

        }

        public ActionResult Update(TBLKATEGORILER model)
        {
            var value = db.TBLKATEGORILER.Find(model.KATEGORIID);
            value.KATEGGORIAD = model.KATEGGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}