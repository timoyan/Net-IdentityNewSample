using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Net_IdentityNewSample.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public Guid ApplicationID { get; set; }

        public ApplicationUser()
        {
            ApplicationID = Guid.NewGuid();
        }

        public class Config : EntityTypeConfiguration<ApplicationUser>
        {
            public Config()
            {
                Property(q => q.UserName).HasColumnType("varchar").HasColumnName("UserAccount").HasMaxLength(300);
                Property(q => q.PhoneNumber).HasColumnType("varchar").HasMaxLength(200);
                ToTable("tbAppUser");
            }
        }
    }
}