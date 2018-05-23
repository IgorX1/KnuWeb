using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeEF;

namespace KnuWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeEF.KNUDBEntities ctx = new EmployeeEF.KNUDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View(ctx.EMPLOYEE.ToList());
        }

        public ActionResult Create()
        {
            EMPLOYEE e = new EMPLOYEE();

            SelectList items = new SelectList(ctx.DEPARTMENT, "ID", "D_NAME");
            ViewBag.Departments = items;
            SelectList items2 = new SelectList(ctx.CATHEDRA, "ID", "C_NAME");
            ViewBag.Cathedras = items2;
            SelectList items3 = new SelectList(ctx.DEGREELIST, "ID", "D_NAME");
            ViewBag.Degrees = items3;

            return View(e);
        }
    }
}