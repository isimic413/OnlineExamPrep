using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class QuestionTypeEntityMap : EntityTypeConfiguration<QuestionTypeEntity>
    {
        public QuestionTypeEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("QuestionType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
        }
    }
}
