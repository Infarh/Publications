using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publications.BlazorUI.ViewModels
{
    public class PublicationViewModel
    {
        public int Id { get; set; }

        public AuthorViewModel Author { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public DateTime Date { get; set; }

        public string Place { get; set; }
    }
}
