using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF
{
    [MetadataType(typeof(EMAILMD))]
    partial class EMAIL
    {
        public class EMAILMD
        {
            [HiddenInput(DisplayValue = false)]
            public int ID { get; set; }

            [Display(Name = "Пошта")]
            [EmailAddress(ErrorMessage = "Неправильна адреса")]
            [UIHint("String")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина поля має знаходитись в межах від 2 до 50 символів")]
            //[RegularExpression( @"[A-Za-z0-9._% + -] + @ [A-Za-z0-9. -] + \. [A-Za-z] {2,4}", ErrorMessage = "Неправильна адреса")]
            public string ADRESS { get; set; }
        }
    }
}
