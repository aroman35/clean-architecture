using System;

namespace CleanArchitecture.Stsutsul.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Semen Semen { get; set; }
        public Guid SemenId { get; set; }
    }
}