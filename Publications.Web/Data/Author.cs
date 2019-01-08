using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Publications.Web.Data
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        /// <summary>Фамилия</summary>
        public string Surname { get; set; }
        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public AuthorPosition Position { get; set; }
        /// <summary>Степень</summary>
        public AuthorDegree Degree { get; set; }
        /// <summary>Звание</summary>
        public AuthorGrade Grade { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }

        public virtual ICollection<AuthorPublication> Publications { get; set; }
    }
}
