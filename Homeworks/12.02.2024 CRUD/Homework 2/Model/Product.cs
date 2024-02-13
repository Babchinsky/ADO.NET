using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2.Model
{
    public class ProductType
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ProductType TypeObj { get; set; }
        public Supplier SupplierObj { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime SupplyDate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
