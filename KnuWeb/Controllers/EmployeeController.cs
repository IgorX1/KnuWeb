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

        [HttpPost, ActionName("Create")]
        public ActionResult EmplopyeeCreate(EMPLOYEE e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.EMPLOYEE.Add(e);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    SelectList items = new SelectList(ctx.DEPARTMENT, "ID", "D_NAME");
                    ViewBag.Departments = items;
                    SelectList items2 = new SelectList(ctx.CATHEDRA, "ID", "C_NAME");
                    ViewBag.Cathedras = items2;
                    SelectList items3 = new SelectList(ctx.DEGREELIST, "ID", "D_NAME");
                    ViewBag.Degrees = items3;
                }
            }
            catch
            {

            }
            return View(e);
        }

        public JsonResult CheckDepartAndCath(int? CATHEDRA, int? DEPARTMENT)
        {
            if(ctx.CATHEDRA.Where(x=>x.ID == CATHEDRA && x.DEPARTMENT_ID==DEPARTMENT).Count()<=0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckYear(int? YEAR_GOT)
        {
            if (YEAR_GOT<1900 || YEAR_GOT>DateTime.Now.Year+1)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}