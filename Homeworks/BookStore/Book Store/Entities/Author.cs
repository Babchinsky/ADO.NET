﻿using System.Collections.Generic;

namespace Book_Store.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{$" {LastName}" ?? string.Empty}{$" {Patronymic}" ?? string.Empty}";
        }
    }
}