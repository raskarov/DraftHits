using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using DraftHits.Data.Cofigs;
using DraftHits.Data.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace DraftHits.Data
{
    public class DraftHitsContext : IdentityDbContext<ApplicationUser>
    {
        public DraftHitsContext()
            : base("DefaultConnection")
        {
        }

        public static DraftHitsContext Create()
        {
            return new DraftHitsContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles").HasKey<String>(r => r.Id);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims").HasKey<Int32>(r => r.Id);
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins").HasKey<String>(l => l.UserId);
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles").HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Configurations.Add(new ApplicationUserConfig());
            modelBuilder.Configurations.Add(new CustomerConfig());
            modelBuilder.Configurations.Add(new CustomerTransactionConfig());
            modelBuilder.Configurations.Add(new CustomerPaymentsLogConfig());
        }
    }
}
