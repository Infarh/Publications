using System.Collections.Generic;
using Publications.Interfaces.Base.Entities;

namespace Publications.DAL.Entities
{
    public class KeyWord : INamedEntity
    {
        public int Id { get; }
        public string Name { get; }

        public ICollection<Publication> Publications { get; set; }
    }
}
