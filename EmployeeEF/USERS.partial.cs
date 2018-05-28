using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF
{
    [MetadataType(typeof(USERSMD))]
    partial class USERS
    {
        public class USERSMD
        {
            [HiddenInput(DisplayValue = false)]
            public int ID { get; set; }
            [UIHint("String")]
            [Display(Name = "Логін")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля має знаходитись в межах від 3 до 50 символів")]           
            public string LOGIN { get; set; }

            [UIHint("Password")]
            [Display(Name = "Пароль")]
            [Required(ErrorMessage = "Поле не повинно бути порожнім")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля має знаходитись в межах від 3 до 50 символів")]
            public string PASSWORD { get; set; }
        }
    }
}
