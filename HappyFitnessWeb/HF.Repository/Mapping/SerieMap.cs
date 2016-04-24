using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class SerieMap : EntityTypeConfiguration<Serie>
    {
        public SerieMap()
        {
            // Primary Key
            this.HasKey(t => t.SerieCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("Serie", "hf");
            this.Property(t => t.SerieCodigo).HasColumnName("SerieCodigo");
            this.Property(t => t.Repeticoes).HasColumnName("Repeticoes");
            this.Property(t => t.Peso).HasColumnName("Peso");
            this.Property(t => t.TempoSegundos).HasColumnName("TempoSegundos");
            this.Property(t => t.ExercicioCodigo).HasColumnName("ExercicioCodigo");
            this.Property(t => t.AtividadeCodigo).HasColumnName("AtividadeCodigo");
            this.Property(t => t.Ordem).HasColumnName("Ordem");

            // Relationships
            this.HasRequired(t => t.Atividade)
                .WithMany(t => t.SerieList)
                .HasForeignKey(d => d.AtividadeCodigo);
            this.HasRequired(t => t.Exercicio)
                .WithMany(t => t.SerieList)
                .HasForeignKey(d => d.ExercicioCodigo);
        }
    }
}
