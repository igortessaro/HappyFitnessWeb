using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class MusculoMap : EntityTypeConfiguration<Musculo>
    {
        public MusculoMap()
        {
            // Primary Key
            this.HasKey(t => t.codMusculo);

            // Tabela
            this.ToTable("Musculo", "hf");
            this.Property(t => t.codMusculo).HasColumnName("codMusculo");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}