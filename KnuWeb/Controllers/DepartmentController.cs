using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using EmployeeEF;

namespace KnuWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private KNUDBEntities ctx = new KNUDBEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View(ctx.DEPARTMENT.ToList());
        }

        public ActionResult Create()
        {
            DEPARTMENT dEPARTMENT = new DEPARTMENT();
            return View(dEPARTMENT);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult DepartmentCreate(DEPARTMENT d)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ctx.DEPARTMENT.Add(d);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {

            }
            return View(d);
        }

        public JsonResult CheckD_NAME(string D_NAME)
        {
            int num = ctx.DEPARTMENT.Count(x => x.D_NAME == D_NAME);
            if (num > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var dep = (from i in ctx.DEPARTMENT
                       where i.ID == id
                       select i).First();
            return View(dep);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DepartmentDelete(int id)
        {
            var dep = (from i in ctx.DEPARTMENT
                       where i.ID == id
                       select i).First();

            int noe = (from i in ctx.EMPLOYEE
                       where i.DEPARTMENT1.ID == id
                       select i).Count();
            if (noe > 0)
            {
                var view = View(dep);
                view.ViewBag.DeleteUnsuccessfull = "До факультета прив'язані співробітники. Видалити неможливо!";
                return view;
            }
       
            try
            {
                ctx.DEPARTMENT.Remove(dep);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dep);
            }
        }
    }
}