using System.ComponentModel.DataAnnotations;

namespace Publications.Web.Data
{
    /// <summary>Степень</summary>
    public class AuthorDegree
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Meta { get; set; }
    }
}