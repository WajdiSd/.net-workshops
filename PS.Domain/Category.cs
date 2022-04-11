using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
   public class Category
    {
        public int CategoryId { get; set; }

        public String Name { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();

    }
}
