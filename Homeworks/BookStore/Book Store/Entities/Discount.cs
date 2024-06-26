﻿using System;
using System.Collections.Generic;

namespace Book_Store.Entities
{
    public class Discount
    {
        public Discount()
        {
            BookDiscounts = new HashSet<BookDiscount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Percent { get; set; }

        public virtual ICollection<BookDiscount> BookDiscounts { get; set; }
    }
}