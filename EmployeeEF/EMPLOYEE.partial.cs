using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF
{
    [MetadataType(typeof(EMPLOYEEMD))]
    partial class EMPLOYEE
    {
        public class EMPLOYEEMD
        {
            [HiddenInput(DisplayValue = false)]
            public int ID { get; set; }

            [Display(Name = "Ім'я")]
            public string NAME_E { get; set; }

            [Display(Name = "Пошта")]
            public int? EMAIL { get; set; }

            [Display(Name = "Факультет")]
            public int? DEPARTMENT { get; set; }

            [Display(Name = "Кафедра")]
            public int? CATHEDRA { get; set; }

            [Display(Name = "Бал")]
            public byte? RATING { get; set; }

            [HiddenInput(DisplayValue = false)]
            public int? PHOTO { get; set; }

        }
    }
}
