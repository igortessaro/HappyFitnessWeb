using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class AtividadeMap : EntityTypeConfiguration<Atividade>
    {
        public AtividadeMap()
        {
            // Primary Key
            this.HasKey(t => t.codAtividade);

            // Tabela
            this.ToTable("Atividade", "hf");
            this.Property(t => t.codAtividade).HasColumnName("codAtividade");
            this.Property(t => t.codTreinoDiario).HasColumnName("codTreinoDiario");
            this.Property(t => t.Series).HasColumnName("Series");
            this.Property(t => t.Repeticoes).HasColumnName("Repeticoes");
            this.Property(t => t.codExercicio).HasColumnName("codExercicio");
            this.Property(t => t.Peso).HasColumnName("Peso");
            this.Property(t => t.Feedback).HasColumnName("Feedback");
        }
    }
}
