using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using Publications.Web.Data;

namespace Publications.Web.Models.Publications
{
    public class OverviewModel
    {
        public IEnumerable<Author> Authors { get; }
        public IEnumerable<Publication> Publications { get; }

        public OverviewModel(IEnumerable<Author> Authors, IEnumerable<Publication> Publications)
        {
            this.Authors = Authors;
            this.Publications = Publications;
        }
    }
}
