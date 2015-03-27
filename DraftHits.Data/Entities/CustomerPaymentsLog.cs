using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHits.Data.Entities
{
    public class CustomerPaymentsLog
    {
        public Int64 Id { get; set; }

        public Int64 CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public Int64 CustomerTransactionId { get; set; }

        public virtual CustomerTransaction CustomerTransaction { get; set; }

        public Decimal PaymentAmount { get; set; }

        public String PaymentProvider { get; set; }

        public String PaymentTransactionId { get; set; }

        public String CustomerIPAddress { get; set; }

        public DateTime DatePayment { get; set; }
    }
}
