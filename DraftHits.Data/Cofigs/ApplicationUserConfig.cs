using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using DraftHits.Data.Entities;

namespace DraftHits.Data.Cofigs
{
    internal class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfig()
        {
            Map(x => 
            { 
                x.ToTable("AspNetUsers");
                x.MapInheritedProperties();
            });
        }
    }
}
