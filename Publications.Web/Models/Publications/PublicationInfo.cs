using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Publications.Web.Models.Publications
{
    public class PublicationInfo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название"), Required]
        public string PublicationName { get; set; }
        [Display(Name = "Дата"), Required]
        public DateTime PublicationDate { get; set; }
    }
}
