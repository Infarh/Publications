﻿using System;
using System.Collections.Generic;

using Publications.Interfaces.Base.Entities;

namespace Publications.DAL.Entities
{
    public class Publication : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Author> Authors { get; set; }
        public PublicationPlace Place { get; set; }

        public ICollection<KeyWord> KeyWords { get; set; }

        public double Size { get; set; }
    }
}