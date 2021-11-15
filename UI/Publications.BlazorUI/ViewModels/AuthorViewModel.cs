using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publications.BlazorUI.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public int PublicationsCount { get; set; }
    }
}
