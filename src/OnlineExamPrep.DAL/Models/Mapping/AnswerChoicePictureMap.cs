using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class AnswerChoicePictureEntityMap : EntityTypeConfiguration<AnswerChoicePictureEntity>
    {
        public AnswerChoicePictureEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.AnswerChoiceId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Image)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AnswerChoicePicture");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AnswerChoiceId).HasColumnName("AnswerChoiceId");
            this.Property(t => t.Image).HasColumnName("Image");

            // Relationships
            this.HasRequired(t => t.AnswerChoice)
                .WithMany(t => t.AnswerChoicePictures)
                .HasForeignKey(d => d.AnswerChoiceId);

        }
    }
}
