using LojaDesafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business
{
    public class CreditCardBusiness
    {
        public void Validate(CreditCard creditcard)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(creditcard.Cardholder))
            {
                errors.Add("No cardholder in credit card.");
            }

            bool validDate = true;

            if (creditcard.ExpirationMonth <= 0 || creditcard.ExpirationMonth > 12)
            {
                validDate = false;
                errors.Add("Invalid expiration month.");
            }

            if (creditcard.ExpirationYear <= DateTime.Now.Year)
            {
                validDate = false;
                errors.Add("Invalid expiration year.");
            }

            if (validDate)
            {
                // Gets the last day of the month
                var expirationDate = new DateTime(creditcard.ExpirationYear, creditcard.ExpirationMonth, 1).AddMonths(1).AddDays(-1);

                if (expirationDate < DateTime.Now)
                {
                    errors.Add("Card is no longer valid.");
                }
            }

            if (string.IsNullOrEmpty(creditcard.CSC))
            {
                errors.Add("No CSC in credit card.");
            }

            if (string.IsNullOrEmpty(creditcard.Number))
            {
                errors.Add("No number in credit card.");
            }

            if (creditcard.CardIssuer == CreditCard.Issuer.None)
            {
                errors.Add("No issuer in credit card.");
            }

            if (errors.Count > 0)
            {
                throw new Exception();
            }
        }
    }
}
