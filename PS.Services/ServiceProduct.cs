using PS.Data;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public class ServiceProduct : IserviceProduct
    {

        PSContext ctx = new PSContext();

        public void Add(Product p)
        {
            ctx.Products.Add(p);
        }

        public void Commit()
        {
            ctx.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return ctx.Products;
        }

        public void Remove(Product p)
        {
            ctx.Products.Remove(p);

        }
    }
}
