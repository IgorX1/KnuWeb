using System;
using System.Collections.Generic;
using System.IO;
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
            
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if(file!=null && file.ContentLength > 0)
                {
                    var stream = file.InputStream;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        PHOTO pHOTO = new PHOTO
                        {
                            IMAGEDATA = ms.ToArray()

                        };
                        e.PHOTO1 = pHOTO;
                    }
                }
            }
            
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

        public ActionResult Delete(int id)
        {
            var c = (from i in ctx.EMPLOYEE
                     where i.ID == id
                     select i).First();
            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult EmployeeDelete(int id)
        {
            EMPLOYEE eMPLOYEE = (from i in ctx.EMPLOYEE
                                 where i.ID == id
                                 select i).First();
            //ctx.PHOTO.Remove(eMPLOYEE.PHOTO1);
            ctx.DEGREE.Remove(eMPLOYEE.DEGREE1);
            ctx.EMAIL.Remove(eMPLOYEE.EMAIL1);
            ctx.EMPLOYEE.Remove(eMPLOYEE);
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var c = (from i in ctx.EMPLOYEE
                     where i.ID == id
                     select i).First();

            SelectList items = new SelectList(ctx.DEPARTMENT, "ID", "D_NAME");
            ViewBag.Departments = items;
            SelectList items2 = new SelectList(ctx.CATHEDRA, "ID", "C_NAME");
            ViewBag.Cathedras = items2;
            SelectList items3 = new SelectList(ctx.DEGREELIST, "ID", "D_NAME");
            ViewBag.Degrees = items3;

            return View(c);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EmplopyeeEdit(int id, FormCollection collection)
        {
            var e = (from i in ctx.EMPLOYEE
                     where i.ID == id
                     select i).First();

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var stream = file.InputStream;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        PHOTO pHOTO = new PHOTO
                        {
                            IMAGEDATA = ms.ToArray()

                        };
                        e.PHOTO1 = pHOTO;
                    }
                }
            }

            try
            {
                if (ModelState.IsValid)
                {
                    UpdateModel(e);
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

        public ActionResult Details(int id)
        {
            var c = (from i in ctx.EMPLOYEE
                     where i.ID == id
                     select i).First();
            return View(c);
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