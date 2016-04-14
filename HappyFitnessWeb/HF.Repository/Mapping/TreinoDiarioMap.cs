using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class TreinoDiarioMap : EntityTypeConfiguration<TreinoDiario>
    {
        public TreinoDiarioMap()
        {
            // Primary Key
            this.HasKey(t => t.TreinoDiarioCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("TreinoDiario", "hf");
            this.Property(t => t.TreinoDiarioCodigo).HasColumnName("TreinoDiarioCodigo");
            this.Property(t => t.TreinoCodigo).HasColumnName("TreinoCodigo");
            this.Property(t => t.Tipo).HasColumnName("Tipo");

            // Relationships
            this.HasRequired(t => t.Treino)
                .WithMany(t => t.TreinoDiarioList)
                .HasForeignKey(d => d.TreinoCodigo);

        }
    }
}
