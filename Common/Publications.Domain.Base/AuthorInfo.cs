using Publications.Interfaces.Base.Entities;

namespace Publications.Domain.Base
{
    public class AuthorInfo : INamedEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
}
