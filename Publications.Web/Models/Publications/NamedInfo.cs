using System.ComponentModel.DataAnnotations;

namespace Publications.Web.Models.Publications
{
    public abstract class NamedInfo : Info
    {
        [Display(Name = "Имя"), Required]
        public string Name { get; set; }
    }
}