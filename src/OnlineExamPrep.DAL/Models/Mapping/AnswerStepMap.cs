using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class AnswerStepEntityMap : EntityTypeConfiguration<AnswerStepEntity>
    {
        public AnswerStepEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.QuestionId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Text)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AnswerStep");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Points).HasColumnName("Points");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.AnswerSteps)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
