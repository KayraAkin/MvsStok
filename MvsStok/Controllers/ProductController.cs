using MvsStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvsStok.Controllers
{
    public class ProductController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.TBLURUNLAR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGGORIAD,
                                               Value=i.KATEGORIID.ToString(),
                                           }).ToList();
            ViewBag.dgr = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(TBLURUNLAR model)
        {
            var values =db.TBLKATEGORILER.Where(x=> x.KATEGORIID == model.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            model.TBLKATEGORILER = values;
            db.TBLURUNLAR.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = db.TBLURUNLAR.Find(id);
            db.TBLURUNLAR.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GeyByIdProduct(int id)
        {

            List<SelectListItem> values = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGGORIAD,
                                               Value = i.KATEGORIID.ToString(),
                                           }).ToList();
            ViewBag.dgr = values;
            var value = db.TBLURUNLAR.Find(id);
            return View("GeyByIdProduct", value);
        }
        public ActionResult Update(TBLURUNLAR model)
        {
            var value = db.TBLURUNLAR.Find(model.URUNID);
            value.URUNAD = model.URUNAD;
            value.MARKA = model.MARKA;
            value.FIYAT = model.FIYAT;
            value.STOK = model.STOK;
            //value.URUNKATEGORI=model.URUNKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(x => x.KATEGORIID == model.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            value.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}