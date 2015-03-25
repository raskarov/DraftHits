using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftHits_CF.Models
{
  public  class Customer
    {
      [Required]
      public long Id { get; set; }

      [Column(TypeName="Money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "Money")]
        public decimal PendingBonus { get; set; }

        public int DHRP { get; set; }

        public Boolean AccountLocked { get; set; }

        public Boolean ShipmentLocked { get; set; }

        public Boolean FirstTimeBonus { get; set; }

        public DateTime? FirstTimeBonusDate { get; set; }

        public string ReferralCode { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
      public Customer()
        {
            Balance = 0;
            PendingBonus = 0;
            DHRP = 0;
            AccountLocked = false; 
           ShipmentLocked = false;
           FirstTimeBonus = false;
           ReferralCode = "";
        }

       
    }

  public enum CustomerTransactionType 
  {
  EntryFee,PendingBonusEarned,WinningsCash,WinningsShipment,Payment,Withdrawal
  }


    public class CustomerTransaction
    {
        public long ID { get; set; }
        public long CustomerId { get; set; }

        [Column(TypeName = "Money")]
        public decimal Credit { get; set; }

        [Column(TypeName = "Money")]
        public decimal Debit { get; set; }

        public DateTime TransactionDate { get; set; }

        public CustomerTransactionType CustomerTransactionType { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
