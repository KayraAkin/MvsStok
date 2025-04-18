using MvsStok.Models.Entity;
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
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TBLKATEGORILER model)
        {
            db.TBLKATEGORILER.Add(model);
            db.SaveChanges();
            return View();
        }
    }
}