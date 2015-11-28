using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Model
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Cardholder { get; set; }
        public string Number { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public Issuer CardIssuer { get; set; }
        public string CSC { get; set; }

        public enum Issuer
        {
            None = 0,
            Visa = 1,
            MasterCard = 2,
            AmericanExpress = 3
        }
    }
}
