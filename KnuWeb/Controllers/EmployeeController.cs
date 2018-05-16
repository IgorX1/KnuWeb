using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}