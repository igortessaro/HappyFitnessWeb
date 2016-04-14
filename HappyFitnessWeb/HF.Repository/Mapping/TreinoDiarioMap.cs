using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class TreinoDiarioMap : EntityTypeConfiguration<TreinoDiario>
    {
        public TreinoDiarioMap()
        {
            // Primary Key
            this.HasKey(t => t.codTreinoDiario);

            // Tabela
            this.ToTable("TreinoDiario", "hf");
            this.Property(t => t.codTreinoDiario).HasColumnName("codTreinoDiario");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
        }
    }
}

