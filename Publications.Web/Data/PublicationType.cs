using System.ComponentModel.DataAnnotations;

namespace Publications.Web.Data
{
    public class PublicationType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Meta { get; set; }
    }
}