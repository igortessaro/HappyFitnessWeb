using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class ExercicioMap : EntityTypeConfiguration<Exercicio>
    {
        public ExercicioMap()
        {
            // Primary Key
            this.HasKey(t => t.ExercicioCodigo);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Descricao)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Exercicio", "hf");
            this.Property(t => t.ExercicioCodigo).HasColumnName("ExercicioCodigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
