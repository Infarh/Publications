using Publications.Interfaces.Base.Entities;

namespace Publications.Domain.Base
{
    public class PublicationPlaceInfo : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
