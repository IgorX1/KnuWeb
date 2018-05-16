using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeEF;

namespace KnuWeb.Controllers
{
    public class CathedraController : Controller
    {
        private KNUDBEntities ctx = new KNUDBEntities();
        // GET: Cathedra
        public ActionResult Index()
        {
            return View(ctx.CATHEDRA.ToList());
        }

        public ActionResult Create()
        {
            CATHEDRA cATHEDRA = new CATHEDRA();
            SelectList items = new SelectList(ctx.DEPARTMENT, "ID", "D_NAME");
            ViewBag.Departments = items;
            return View(cATHEDRA);
        }
    }
}