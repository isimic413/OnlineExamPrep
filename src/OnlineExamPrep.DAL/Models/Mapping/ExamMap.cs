using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class ExamEntityMap : EntityTypeConfiguration<ExamEntity>
    {
        public ExamEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.TestingAreaId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Exam");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TestingAreaId).HasColumnName("TestingAreaId");
            this.Property(t => t.DurationInMinutes).HasColumnName("DurationInMinutes");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Term).HasColumnName("Term");

            // Relationships
            this.HasRequired(t => t.TestingArea)
                .WithMany(t => t.Exams)
                .HasForeignKey(d => d.TestingAreaId);

        }
    }
}
