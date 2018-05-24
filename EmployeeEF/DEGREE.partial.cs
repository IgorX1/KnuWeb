using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF
{
    [MetadataType(typeof(DEGREEMD))]
    partial class DEGREE
    {
        public class DEGREEMD
        {
            [HiddenInput(DisplayValue = false)]
            public int ID { get; set; }

            
            [Range(1900, 2018, ErrorMessage ="Задайте рік числового типу в адекватному діапазоні")]
            [Remote("CheckYear", "Employee", ErrorMessage = "Задайте рік числового типу в адекватному діапазоні")]
            public int? YEAR_GOT { get; set; }
        }

    }
}
