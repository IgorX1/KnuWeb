using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF
{
    [MetadataType(typeof(CATHEDRAMD))]
    partial class CATHEDRA
    {
        public class CATHEDRAMD
        {
            [HiddenInput(DisplayValue = false)]
            public int ID { get; set; }

            [Display(Name = "Кафедра")]
            public string C_NAME { get; set; }

            [Display(Name = "Факультет")]
            public int DEPARTMENT_ID { get; set; }

        }
    }
}
