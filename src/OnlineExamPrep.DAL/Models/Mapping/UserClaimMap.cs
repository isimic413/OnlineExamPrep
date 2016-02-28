using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class UserClaimEntityMap : EntityTypeConfiguration<UserClaimEntity>
    {
        public UserClaimEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("UserClaim");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ClaimType).HasColumnName("ClaimType");
            this.Property(t => t.ClaimValue).HasColumnName("ClaimValue");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserClaims)
                .HasForeignKey(d => d.UserId);

        }
    }
}
