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
                    int num = (from i in ctx.DEPARTMENT
                               where i.D_NAME == d.D_NAME
                               select i).Count();
                    /*if(num>0)
                    {
                        Response.Write("<script>alert('Цей факультет вже існує')</script>");
                        return View(d);
                    }*/

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
    }
}