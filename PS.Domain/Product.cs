using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
   public class Product
    {
        //public Product(int productId, string name, double price, DateTime dateProd, string description, int quantity, List<Provider> providers)
        //{
        //    ProductId = productId;
        //    Name = name;
        //    Price = price;
        //    DateProd = dateProd;
        //    Description = description;
        //    Quantity = quantity;
        //    Providers = providers;
        //}

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, ErrorMessage = "The Name value cannot exceed 25 characters. ")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Display(Name="Production Date")]
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }

        public string ImageName { get; set; }
        [DataType(DataType.MultilineText)]
        public string  Description { get; set; }

        [ForeignKey("CategoryFK")]
        public int? CategoryFK { get; set; }
        public virtual Category Category { get; set; }

        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        public virtual List<Provider> Providers { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<Achat> Achats { get; set; }


        public override string ToString()
        {
            return "name : " + Name + " description : " + Description + " Quantity : " + Quantity + " Category : " + Category;
        }

        /*
         * forcer le passage par reference /
        public void Calculer(int a , int b ,ref int c)
        {
            c = a + b;
            Console.WriteLine(c);
        }*/

        public virtual void GetMyType()
        {
            Console.Write("je suis un produit");
        }
    }
}
