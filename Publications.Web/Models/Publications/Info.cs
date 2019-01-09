using Microsoft.AspNetCore.Mvc;

namespace Publications.Web.Models.Publications
{
    public abstract class Info
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}