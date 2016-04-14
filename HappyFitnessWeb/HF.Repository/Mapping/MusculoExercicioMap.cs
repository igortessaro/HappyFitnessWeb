using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class MusculoExercicioMap : EntityTypeConfiguration<MusculoExercicio>
    {
        public MusculoExercicioMap()
        {
            // Primary Key
            this.HasKey(t => t.MusculoExercicioCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("MusculoExercicio", "hf");
            this.Property(t => t.MusculoExercicioCodigo).HasColumnName("MusculoExercicioCodigo");
            this.Property(t => t.MusculoCodigo).HasColumnName("MusculoCodigo");
            this.Property(t => t.ExercicioCodigo).HasColumnName("ExercicioCodigo");

            // Relationships
            this.HasRequired(t => t.Exercicio)
                .WithMany(t => t.MusculoExercicioList)
                .HasForeignKey(d => d.ExercicioCodigo);
            this.HasRequired(t => t.Musculo)
                .WithMany(t => t.MusculoExercicioList)
                .HasForeignKey(d => d.MusculoCodigo);

        }
    }
}
