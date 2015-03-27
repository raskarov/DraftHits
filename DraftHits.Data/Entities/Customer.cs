using System;
using System.Collections.Generic;

namespace DraftHits.Data.Entities
{
    public class Customer
    {
        public Int64 Id { get; set; }

        public Decimal Balance { get; set; }

        public Decimal PendingBonus { get; set; }

        public Int32 DHRP { get; set; }

        public Boolean AccountLocked { get; set; }

        public Boolean ShipmentLocked { get; set; }

        public Boolean FirstTimeBonus { get; set; }

        public DateTime? DateFirstTimeBonus { get; set; }

        public String ReferralCode { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }

        public virtual ICollection<CustomerPaymentsLog> CustomerPaymentsLogs { get; set; }
    }
}
