using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class AcademiaMap : EntityTypeConfiguration<Academia>
    {
        public AcademiaMap()
        {
            // Primary Key
            this.HasKey(t => t.AcademiaCodigo);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Academia", "hf");
            this.Property(t => t.AcademiaCodigo).HasColumnName("AcademiaCodigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Situacao).HasColumnName("Situacao");
        }
    }
}
