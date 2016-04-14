using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class AparelhoExercicioMap : EntityTypeConfiguration<AparelhoExercicio>
    {
        public AparelhoExercicioMap()
        {
            // Primary Key
            this.HasKey(t => t.AparelhoExercicioCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("AparelhoExercicio", "hf");
            this.Property(t => t.AparelhoExercicioCodigo).HasColumnName("AparelhoExercicioCodigo");
            this.Property(t => t.ExercicioCodigo).HasColumnName("ExercicioCodigo");
            this.Property(t => t.AparelhoCodigo).HasColumnName("AparelhoCodigo");

            // Relationships
            this.HasRequired(t => t.Aparelho)
                .WithMany(t => t.AparelhoExercicios)
                .HasForeignKey(d => d.AparelhoCodigo);
            this.HasRequired(t => t.Exercicio)
                .WithMany(t => t.AparelhoExercicios)
                .HasForeignKey(d => d.ExercicioCodigo);

        }
    }
}
