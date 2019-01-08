using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Publications.Web.Data
{
    public class Publication
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public PublicationType Type { get; set; }
        public PublicationPlace Place { get; set; }

        public string Description { get; set; }
        public string Meta { get; set; }

        public virtual ICollection<AuthorPublication> Authors { get; set; }
    }
}
