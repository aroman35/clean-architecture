using System;
using System.Collections.Generic;

namespace CleanArchitecture.Stsutsul.Domain
{
    public class Semen
    {
        public Semen()
        {
            Books = new HashSet<Book>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Happiness { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}