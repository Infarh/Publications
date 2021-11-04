using System;
using System.Collections.Generic;
using Publications.Interfaces.Base.Entities;

namespace Publications.Domain.Base
{
    public class PublicationInfo : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<AuthorInfo> Authors { get; set; } = new HashSet<AuthorInfo>();
        public PublicationPlaceInfo Place { get; set; }
    }
}
