using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
  public  class Provider : Concept
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        [Key] // in this case , this is useless because our PK is [className]Id but we use [key] annotation when the name is different
        public int ProviderId { get; set; }

        public Boolean IsApproved { get; set; }

        /**
         * password.Length has to be between 5 and 20 , therefore 
         * we will work with the following syntax for the 
         * attribute // setters // getters
         */
        
        private String password;
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="password is required")]
        [MinLength(8,ErrorMessage ="password has to contain less than 8 chars")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 20 && value.Length > 5)
                    password = value;
                else
                    Console.WriteLine("invalid password !");
            }
        }


        private String confirmPassword;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "confirmPassword is required")]
        [MinLength(8, ErrorMessage = "password has to contain less than 8 chars")]
        [NotMapped]
        [Compare("passwords must match")]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value== password)
                    confirmPassword = value;
                else
                    Console.WriteLine("password and confirmPassword must be identical !");
            }
        }

        public String Username { get; set; }

       // public DateTime DateCreated { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();



        public static void SetIsApproved(Provider p)
        {
            /* if (p.password == p.confirmPassword)
                 p.IsApproved = true;
             else
                 p.IsApproved = false;*/

            p.IsApproved = (p.password == p.confirmPassword);
        }

        public static void SetIsApproved(string password, string confirmPassword,bool isApproved)
        {
            isApproved = (password == confirmPassword);
        }

        //start polymorphisme

        /**
         * polymorphisme : méthodes 
         * 
        */

       /* public bool Login(string user,string password)
        {
            return user ==  Username && password == Password ;
        }
       */
        public bool Login(string user, string password,string email=null)
        {
            if (email == null)
                return user.Equals(Username) && password.Equals(Password);
            else 
                return user.Equals(Username) && password.Equals(Password) && email.Equals(Email);
        }

        public override void GetDetails()
        {
            Console.WriteLine("nom : "+Username+"\n");
            /*for(int i=0;i<Products.Count;i++)
                Console.WriteLine("n"+i+" : "+Products[i]);
            */
            foreach(Product p in Products)
                Console.WriteLine(p);
        }

        /**
         * displays products selon l'attribut passé 
         */
        public void GetProducts(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Name":
                    foreach(Product p in Products)
                        if(p.Name.Equals(filterValue))
                        Console.WriteLine(p);
                    break;
                case "DateProd":
                    foreach (Product p in Products)
                        if (p.DateProd == DateTime.Parse(filterValue))
                            Console.WriteLine(p);
                    break;
                case "Price":
                    foreach (Product p in Products)
                        if (p.Price == double.Parse(filterValue))
                            Console.WriteLine(p);
                    break;
            }
                
                
        }


    }
}

