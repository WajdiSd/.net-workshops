using System;
using System.Collections.Generic;
using PS.Data;
using PS.Domain;
using PS.Services;

namespace PS.GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            p.Name = "Pomme de terre";
            p.DateProd = new DateTime(2012, 11, 23);
            Console.WriteLine(p.Name.ToString());

            // initialiseur d'objet : 
            Product p2 = new Product
            {
                Name = "fraise",
                Price = 1.5,
                Description = " mal à l'aise",
                DateProd = DateTime.Now
            };
            Category c = new Category { Name = "legume" };
            p2.Category = c;
            Console.WriteLine(p2.ToString());

            Provider provider = new Provider
            {
                //invalid password will be given  (Length not between 5 and 20 )
                //Password = "abd",
                //and now the valid password 
                Password = "1234569",
                ConfirmPassword = "1234569",
                Username = "user1",
                Email = "user1@mail.com"
            };

            Console.WriteLine("provider.isApproved = "+ provider.IsApproved);
            //Provider.SetIsApproved(provider);

            //pour tester le passage par valeur -->
            Provider.SetIsApproved(provider.Password,provider.ConfirmPassword, provider.IsApproved);
            Console.WriteLine("provider.isApproved = " + provider.IsApproved);

           

            Console.WriteLine("la méthode login avec 2 params : ");
            Console.WriteLine(provider.Login("user1", "1234569"));
            Console.WriteLine("la méthode login avec 3 params : ");
            Console.WriteLine(provider.Login("user2", "1234569", "user1@mail.com"));

            // tester la méthode getMyType

            //Product product = new Product();
            Product chemical = new Chemical();
            Biological biological = new Biological();

            //product.GetMyType();
            chemical.GetMyType();
            biological.GetMyType();

            //provider.Products = new List<Product>() { p,p2 };
            provider.Products.Add(p);
            provider.Products.Add(p2);
            provider.GetDetails();
            Console.WriteLine("------------");
            provider.GetProducts("Name", "fraise");
            provider.GetProducts("DateProd", "2012/11/23");


            Console.WriteLine("tester DisplayUsernameAndEmail");
            ManageProvider mp = new ManageProvider();
            mp.providers.Add(provider);
            mp.DisplayUsernameAndEmail("user1");

            // tester délégué 
            Console.WriteLine("testing délégué'");
            ManageProduct mprod = new ManageProduct();
            mprod.lsProduct = new List<Product> { p, p2 };
            foreach (Product pr in mprod.FindProduct('f'))
            {
                Console.WriteLine(pr);
            }

            string s = "test Majuscule";
            s.FirstCharToUpper();

            //insertion dans la bd

            //PSContext ctx = new PSContext();
            ServiceProduct ps = new ServiceProduct();
            ServiceCategory cs = new ServiceCategory();

            //ctx.Products.Add(p);
            ps.Add(p);

            //ctx.Biologicals.Add(biological);
            //ctx.Products.Add(p2);
            //ctx.SaveChanges();
            ps.Commit();


            foreach (Product prod in ps.GetAll())
            {
                Console.WriteLine("product: "+prod.Name);
            }

        }
    }
}
