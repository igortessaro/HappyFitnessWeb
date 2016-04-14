using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class ExercicioMap : EntityTypeConfiguration<Exercicio]>
    {
        public ExercicioMap()
        {
            // Primary Key
            this.HasKey(t => t.codExercicio);

            // Tabela
            this.ToTable("Exercicio", "hf");
            this.Property(t => t.codExercicio).HasColumnName("codExercicio");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
