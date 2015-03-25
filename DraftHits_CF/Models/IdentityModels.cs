using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DraftHits_CF.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FullName { get; set; }
        public string AliasName { get; set; }
        public DateTime CreationDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual Customer Customer { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
              .HasRequired<ApplicationUser>(profile => profile.User);

            base.OnModelCreating(modelBuilder);
        }

    }

   // public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
   // {
   //     public DbSet<Customer> Customer { get; set; }


   //     public ApplicationDbContext()
   //         : base("DefaultConnection", throwIfV1Schema: false)
   //     {
   //     }

   //     //public static ApplicationDbContext Create()
   //     //{
   //     //    return new ApplicationDbContext();
   //     //}

   //     protected override void OnModelCreating
   //(
   //DbModelBuilder modelBuilder
   //)
   //     {
   //         modelBuilder.Entity<Customer>()
   //           .HasRequired<ApplicationUser>(profile => profile.User );

   //         base.OnModelCreating(modelBuilder);
   //     }


   // }

}