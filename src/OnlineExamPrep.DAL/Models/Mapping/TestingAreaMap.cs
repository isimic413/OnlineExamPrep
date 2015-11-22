using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineExamPrep.DAL.Models.Mapping
{
    public class TestingAreaEntityMap : EntityTypeConfiguration<TestingAreaEntity>
    {
        public TestingAreaEntityMap()
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
            this.ToTable("TestingArea");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
        }
    }
}
