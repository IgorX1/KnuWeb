using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF
{
    [MetadataType(typeof(DEPARTMENTMD))]
    partial class DEPARTMENT
    {
        public class DEPARTMENTMD
        {
            [HiddenInput(DisplayValue = false)]
            public int ID { get; set; }

            [Display(Name = "Факультет")]
            public string D_NAME { get; set; }
        }
    }
}
