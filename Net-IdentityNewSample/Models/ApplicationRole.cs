using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Net_IdentityNewSample.Models
{
    public class ApplicationRole: IdentityRole
    {
        [Required]
        public Guid ApplicationID { get; set; }

        public ApplicationRole()
        {
            ApplicationID = Guid.NewGuid();
        }

        public class Config : EntityTypeConfiguration<ApplicationRole>
        {
            public Config()
            {
                Property(q => q.Name).HasColumnName("RoleName");
                ToTable("tbAppRole");
            }
        }
    }
}