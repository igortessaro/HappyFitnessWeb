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

            // Tabela
            this.ToTable("Academia", "hf");
            this.Property(t => t.AcademiaCodigo).HasColumnName("AcademiaCodigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
