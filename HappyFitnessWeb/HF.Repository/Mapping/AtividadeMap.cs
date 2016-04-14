using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class AtividadeMap : EntityTypeConfiguration<Atividade>
    {
        public AtividadeMap()
        {
            // Primary Key
            this.HasKey(t => t.AtividadeCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("Atividade", "hf");
            this.Property(t => t.AtividadeCodigo).HasColumnName("AtividadeCodigo");
            this.Property(t => t.TreinoDiarioCodigo).HasColumnName("TreinoDiarioCodigo");
            this.Property(t => t.SerieCodigo).HasColumnName("SerieCodigo");
            this.Property(t => t.Feedback).HasColumnName("Feedback");

            // Relationships
            this.HasRequired(t => t.Serie)
                .WithMany(t => t.AtividadeList)
                .HasForeignKey(d => d.SerieCodigo);
            this.HasRequired(t => t.TreinoDiario)
                .WithMany(t => t.AtividadeList)
                .HasForeignKey(d => d.TreinoDiarioCodigo);

        }
    }
}
