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

        [HttpPost, ActionName("Create")]
        public ActionResult DepartmentCreate(CATHEDRA c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.CATHEDRA.Add(c);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            return View(c);
        }

        public ActionResult Delete(int id)
        {
            var c = (from i in ctx.CATHEDRA
                       where i.ID == id
                       select i).First();
            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult CathedraDelete(int id)
        {
            var cath = (from i in ctx.CATHEDRA
                        where i.ID == id
                        select i).First();

            if(ctx.EMPLOYEE.Where(x=>x.CATHEDRA == id).Select(x => x).Count()>0)
            {
                var view = View(cath);
                view.ViewBag.DeleteUnsuccessfull = "До кафедри прив'язані співробітники. Видалити неможливо!";
                return view;
            }

            try
            {
                if(ModelState.IsValid)
                {
                    ctx.CATHEDRA.Remove(cath);
                    ctx.SaveChanges();                   
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cath);
            }
            
        }

        public JsonResult CheckC_NAME(string C_NAME, int DEPARTMENT_ID)
        {
            int num = ctx.CATHEDRA.Count(x => x.C_NAME == C_NAME && x.DEPARTMENT_ID == DEPARTMENT_ID);
            if (num > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}