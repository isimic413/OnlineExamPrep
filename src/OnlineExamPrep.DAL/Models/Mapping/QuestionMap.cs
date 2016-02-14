using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class QuestionEntityMap : EntityTypeConfiguration<QuestionEntity>
    {
        public QuestionEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.QuestionTypeId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Text)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Question");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionTypeId).HasColumnName("QuestionTypeId");
            this.Property(t => t.Text).HasColumnName("Text");

            // Relationships
            this.HasRequired(t => t.QuestionType)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.QuestionTypeId);

        }
    }
}
