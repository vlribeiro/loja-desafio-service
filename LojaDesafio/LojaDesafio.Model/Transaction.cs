using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        [ForeignKey("CreditCard")]
        public int CreditCardId { get; set; }

        [NotMapped]
        public decimal Value
        {
            get
            {
                return this.TransactionProducts != null && this.TransactionProducts.Count > 0 ? this.TransactionProducts.Sum(tp => tp.Quantity * (tp.Product != null ? tp.Product.Price : 0)) : 0;
            }
        }

        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
