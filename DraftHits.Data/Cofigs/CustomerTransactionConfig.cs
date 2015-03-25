using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using DraftHits.Data.Entities;

namespace DraftHits.Data.Cofigs
{
    internal class CustomerTransactionConfig : EntityTypeConfiguration<CustomerTransaction>
    {
        public CustomerTransactionConfig()
        {
            ToTable("CustomerTransaction");
            HasKey(x => x.Id);

            Property(x => x.Credit).IsRequired();
            Property(x => x.Debit).IsRequired();
            Property(x => x.DateTransaction).IsRequired();
            Property(x => x.CustomerTransactionType).IsRequired();

            HasRequired(x => x.Customer).WithMany(x => x.CustomerTransactions).HasForeignKey(x => x.CustomerId);
        }
    }
}
