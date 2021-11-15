using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Publications.Interfaces.Base.Entities;

namespace Publications.Domain.Base
{
    /// <summary>Информация о публикации</summary>
    public class PublicationInfo : IEntity, IEquatable<PublicationInfo>
    {
        /// <summary>Системный идентификатор</summary>
        public int Id { get; set; }
        
        /// <summary>Заголовок</summary>
        [Required]
        public string Title { get; set; }

        /// <summary>Аннотация</summary>
        public string Abstract { get; set; }

        /// <summary>Дата</summary>
        public DateTime Date { get; set; }

        /// <summary>Авторы</summary>
        public ICollection<AuthorInfo> Authors { get; set; } = new HashSet<AuthorInfo>();

        /// <summary>Место публикации</summary>
        public PublicationPlaceInfo Place { get; set; }

        /// <summary>Ключевые слова</summary>
        public ICollection<string> KeyWords { get; set; } = new HashSet<string>();

        /// <summary>Размер публикации</summary>
        public double Size { get; set; }

        public bool Equals(PublicationInfo other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || 
                Title == other.Title && 
                Date == other.Date;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PublicationInfo)obj);
        }

        public override int GetHashCode() => HashCode.Combine(Title, Date);

        public static bool operator ==(PublicationInfo left, PublicationInfo right) => Equals(left, right);
        public static bool operator !=(PublicationInfo left, PublicationInfo right) => !Equals(left, right);
    }
}
