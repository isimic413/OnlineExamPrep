using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class UserExamResultEntityMap : EntityTypeConfiguration<UserExamResultEntity>
    {
        public UserExamResultEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ExamId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("UserExamResult");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ExamId).HasColumnName("ExamId");
            this.Property(t => t.DurationInMinutes).HasColumnName("DurationInMinutes");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.CorrectAnswers).HasColumnName("CorrectAnswers");
            this.Property(t => t.TimeTaken).HasColumnName("TimeTaken");

            // Relationships
            this.HasRequired(t => t.Exam)
                .WithMany(t => t.UserExamResults)
                .HasForeignKey(d => d.ExamId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserExamResults)
                .HasForeignKey(d => d.UserId);

        }
    }
}
