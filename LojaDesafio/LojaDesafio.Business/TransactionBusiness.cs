using LojaDesafio.Model;
using LojaDesafio.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business
{
    public class TransactionBusiness
    {
        public Transaction Save(Transaction transaction)
        {
            using (var db = new Context())
            {
                //db.Transactions.
                //if (product.Id > 0)
                //{
                //    var existingProduct = this.SelectById(product.Id);

                //    existingProduct.Description = product.Description;
                //    existingProduct.Name = product.Name;
                //    existingProduct.Price = product.Price;
                //}
                //else
                //{
                //    db.Products.Add(product);
                //}

                //db.SaveChanges();
            }

            return transaction;
        }

        private void Validate(Transaction transaction)
        {
            List<string> errors = new List<string>();

            if (transaction.CreditCard == null)
            {
                errors.Add("No Credit Card in transaction.");
            }
            else
            {
                try
                {
                    new CreditCardBusiness().Validate(transaction.CreditCard);
                }
                catch (ValidationException e)
                {
                    errors.AddRange(e.Errors);
                }
            }

            if (transaction.TransactionProducts == null)
            {
                errors.Add("No products in transaction.");
            }
            else
            {
                if (transaction.TransactionProducts.Count(tp => tp.Quantity <= 0) > 0)
                {
                    errors.Add("Invalid product quantity in transaction.");
                }

                if (transaction.TransactionProducts.Count(tp => tp.Product.Id <= 0) > 0)
                {
                    errors.Add("Invalid product in transaction.");
                }
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
