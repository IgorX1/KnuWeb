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
            [UIHint("String")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина поля має знаходитись в межах від 2 до 50 символів")]
            public string NAME_E { get; set; }
           
            [Display(Name = "Пошта")]
            [DataType(DataType.EmailAddress)]
            [UIHint("String")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            //[StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина поля має знаходитись в межах від 2 до 50 символів")]
            public int? EMAIL { get; set; }

            [Display(Name = "Факультет")]
            [UIHint("String")]
            //[Remote("CheckDepartAndCath", "Employee", ErrorMessage = "Така кафедра вже існує!", AdditionalFields = "CATHEDRA")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            public int? DEPARTMENT { get; set; }

            [Display(Name = "Кафедра")]
            [UIHint("String")]
            [Remote("CheckDepartAndCath", "Employee", ErrorMessage = "Така кафедри нема на факультеті", AdditionalFields = "DEPARTMENT")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            public int? CATHEDRA { get; set; }

            [Display(Name = "Бал")]
            [UIHint("String")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            public byte? RATING { get; set; }

            [HiddenInput(DisplayValue = false)]
            public int? PHOTO { get; set; }

        }
    }
}
