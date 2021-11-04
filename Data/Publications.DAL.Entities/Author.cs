using System.Collections.Generic;
using Publications.Interfaces.Base.Entities;

namespace Publications.DAL.Entities
{
    public class Author : INamedEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public ICollection<Publication> Publications { get; set; }
    }
}
