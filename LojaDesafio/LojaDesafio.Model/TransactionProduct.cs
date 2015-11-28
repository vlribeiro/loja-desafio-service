using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Model
{
    public class TransactionProduct
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [IgnoreDataMemberAttribute]
        public virtual Product Product { get; set; }
        [IgnoreDataMemberAttribute]
        public virtual Transaction Transaction { get; set; }
    }
}
