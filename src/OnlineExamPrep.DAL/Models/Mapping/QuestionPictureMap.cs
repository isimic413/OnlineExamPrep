using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class QuestionPictureEntityMap : EntityTypeConfiguration<QuestionPictureEntity>
    {
        public QuestionPictureEntityMap()
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

            this.Property(t => t.Image)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("QuestionPicture");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.Image).HasColumnName("Image");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.QuestionPictures)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
