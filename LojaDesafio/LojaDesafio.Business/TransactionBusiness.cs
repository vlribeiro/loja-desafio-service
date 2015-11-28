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

        public Transaction SelectById(int id)
        {
            Transaction transaction = null;

            using (this.Context)
            {
                transaction = this.Context.Transactions.FirstOrDefault(t => t.Id == id);
            }

            return transaction;
        }

        public Transaction Save(Transaction transaction)
        {
            using (this.Context)
            {
                this.Validate(transaction);

                foreach (TransactionProduct tp in transaction.TransactionProducts)
                {
                    Product product = this.Context.Products.FirstOrDefault(p => p.Id == tp.Product.Id);

                    transaction.Value += tp.Quantity * product.Price;
                }

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

                foreach (TransactionProduct tp in transaction.TransactionProducts)
                {
                    if (this.Context.Products.Count(p => p.Id == tp.ProductId) == 0)
                    {
                        errors.Add("Invalid product in transaction.");
                    }
                }
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
