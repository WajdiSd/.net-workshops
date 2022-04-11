using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Domain
{
    public class Client
    {
        [Key]
        public int Cin { get; set; }
        public DateTime DateNaissance { get; set; }
        public String Email { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }


        public virtual List<Achat> Achats { get; set; }
    }
}
