using LojaDesafio.Business.Infrastructure;
using LojaDesafio.Model;
using LojaDesafio.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business
{
    public class TransactionBusiness : GenericBusiness<Transaction>
    {
        public TransactionBusiness(Context context) : base(context) { }

        public Transaction Save(Transaction transaction)
        {
            using (this.Context)
            {
                this.Validate(transaction);

                this.Context.Transactions.Add(transaction);

                this.Context.SaveChanges();
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
                    CreditCardBusiness creditCardBO = (CreditCardBusiness)BusinessFactory.GetInstance().Get<CreditCard>(this.Context);

                    creditCardBO.Validate(transaction.CreditCard);
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

                //ProductBusiness pbo = (ProductBusiness)BusinessFactory.GetInstance().Get<Product>(this.Context);

                //if (transaction.TransactionProducts.Count(tp => pbo.SelectById(tp.ProductId) == null) == 0)
                //{
                //    errors.Add("Invalid product in transaction.");
                //}
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
