using MvsStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvsStok.Controllers
{
    public class SalesController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSale(TBLSATISLAR model)
        {
            db.TBLSATISLAR.Add(model);
            db.SaveChanges();
            return View("Index");
        }
    }
}