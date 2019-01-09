using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Publications.Web.Models.Publications
{
    public class AuthorInfo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string AuthorSurname { get; set; }
        [Display(Name = "Имя"), Required, MinLength(3)]
        public string AuthorName { get; set; }
        [Display(Name = "Отчество")]
        public string AuthorPatronimyc { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? AuthorBirthday { get; set; }
    }
}
