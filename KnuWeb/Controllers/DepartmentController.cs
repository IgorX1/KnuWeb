using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}