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
            [UIHint("String")]
            [Remote("CheckC_NAME", "Cathedra", ErrorMessage = "Така кафедра вже існує!", AdditionalFields = "DEPARTMENT_ID")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            public string C_NAME { get; set; }

            [Display(Name = "Факультет")]
            [UIHint("String")]
            [Remote("CheckC_NAME", "Cathedra", ErrorMessage = "Така кафедра вже існує!", AdditionalFields = "C_NAME")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            public int DEPARTMENT_ID { get; set; }

        }
    }
}
