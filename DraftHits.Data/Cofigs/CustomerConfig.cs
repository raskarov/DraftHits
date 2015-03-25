using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using DraftHits.Data.Entities;

namespace DraftHits.Data.Cofigs
{
    internal class CustomerConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerConfig()
        {
            ToTable("Customer");
            HasKey(x => x.Id);

            Property(x => x.Balance).IsRequired();
            Property(x => x.PendingBonus).IsRequired();
            Property(x => x.DHRP).IsRequired();
            Property(x => x.AccountLocked).IsRequired();
            Property(x => x.ShipmentLocked).IsRequired();
            Property(x => x.FirstTimeBonus).IsRequired();
            Property(x => x.DateFirstTimeBonus).IsOptional();
            Property(x => x.ReferralCode).IsOptional();

            HasRequired(x => x.User).WithRequiredPrincipal(x => x.Customer).Map(x => x.MapKey("CustomerId"));
        }
    }
}
