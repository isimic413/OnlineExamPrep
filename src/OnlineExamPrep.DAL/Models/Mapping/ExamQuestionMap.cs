using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class ExamQuestionEntityMap : EntityTypeConfiguration<ExamQuestionEntity>
    {
        public ExamQuestionEntityMap()
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

            this.Property(t => t.ExamId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("ExamQuestion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.ExamId).HasColumnName("ExamId");
            this.Property(t => t.Number).HasColumnName("Number");

            // Relationships
            this.HasRequired(t => t.Exam)
                .WithMany(t => t.ExamQuestions)
                .HasForeignKey(d => d.ExamId);
            this.HasRequired(t => t.Question)
                .WithMany(t => t.ExamQuestions)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
