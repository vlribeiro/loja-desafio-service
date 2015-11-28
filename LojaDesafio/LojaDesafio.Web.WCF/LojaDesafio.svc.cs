using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LojaDesafio.Model;
using LojaDesafio.Business;
using LojaDesafio.Business.Infrastructure;

namespace LojaDesafio.Web.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LojaDesafio" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LojaDesafio.svc or LojaDesafio.svc.cs at the Solution Explorer and start debugging.
    public class LojaDesafio : ILojaDesafio
    {
        public Product GetProduct(string id)
        {
            var productBO = (ProductBusiness)BusinessFactory.GetInstance().Get<Product>();

            int productId = 0;

            int.TryParse(id, out productId);

            return productBO.SelectById(productId);
        }

        public Product PostProduct(Product product)
        {
            var productBO = (ProductBusiness)BusinessFactory.GetInstance().Get<Product>();

            return productBO.Save(product);
        }

        public Transaction PostTransaction(Transaction transaction)
        {
            var transactionBO = (TransactionBusiness)BusinessFactory.GetInstance().Get<Transaction>();

            return transactionBO.Save(transaction);
        }
    }
}
