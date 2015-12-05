using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class AnswerStepPictureEntityMap : EntityTypeConfiguration<AnswerStepPictureEntity>
    {
        public AnswerStepPictureEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.AnswerStepId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Image)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AnswerStepPicture");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AnswerStepId).HasColumnName("AnswerStepId");
            this.Property(t => t.Image).HasColumnName("Image");

            // Relationships
            this.HasRequired(t => t.AnswerStep)
                .WithMany(t => t.AnswerStepPictures)
                .HasForeignKey(d => d.AnswerStepId);

        }
    }
}
