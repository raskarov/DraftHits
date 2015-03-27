using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using DraftHits.Data.Entities;

namespace DraftHits.Data.Cofigs
{
    internal class CustomerPaymentsLogConfig : EntityTypeConfiguration<CustomerPaymentsLog>
    {
        public CustomerPaymentsLogConfig()
        {
            ToTable("CustomerPaymentsLog");
            HasKey(x => x.Id);

            Property(x => x.PaymentAmount).IsRequired();
            Property(x => x.PaymentProvider).IsRequired();
            Property(x => x.PaymentTransactionId).IsRequired();
            Property(x => x.CustomerIPAddress).IsRequired();
            Property(x => x.DatePayment).IsRequired();

            HasRequired(x => x.Customer).WithMany(x => x.CustomerPaymentsLogs).HasForeignKey(x => x.CustomerId);
            HasRequired(x => x.CustomerTransaction).WithMany(x => x.CustomerPaymentsLogs).HasForeignKey(x => x.CustomerTransactionId);
        }
    }
}
