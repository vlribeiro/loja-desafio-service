using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LojaDesafio.Model;
using LojaDesafio.Business;

namespace LojaDesafio.Web.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LojaDesafio" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LojaDesafio.svc or LojaDesafio.svc.cs at the Solution Explorer and start debugging.
    public class LojaDesafio : ILojaDesafio
    {
        public string GetProduct(string id)
        {
            return "Produto " + id;
        }

        public Product PostProduct(Product product)
        {
            return new ProductBusiness().Save(product);
        }

        public Transaction PostTransaction(Transaction transaction)
        {
            return new TransactionBusiness().Save(transaction);
        }
    }
}
