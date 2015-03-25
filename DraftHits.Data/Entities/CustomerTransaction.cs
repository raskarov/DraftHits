using DraftHits.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHits.Data.Entities
{
    public class CustomerTransaction
    {
        public Int64 Id { get; set; }

        public Decimal Credit { get; set; }

        public Decimal Debit { get; set; }

        public DateTime DateTransaction { get; set; }

        public CustomerTransactionType CustomerTransactionType { get; set; }

        public Int64 CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
