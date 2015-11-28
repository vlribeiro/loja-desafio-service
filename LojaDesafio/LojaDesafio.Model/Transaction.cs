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
                return this.TransactionProducts.Sum(tp => tp.Quantity * tp.Product.Price);
            }
        }

        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
