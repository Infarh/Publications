using System.Collections.Generic;
using Publications.Interfaces.Base.Entities;

namespace Publications.DAL.Entities
{
    public class PublicationPlace : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Publication> Publications { get; set; }
    }
}
