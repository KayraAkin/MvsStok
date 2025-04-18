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
    }
}