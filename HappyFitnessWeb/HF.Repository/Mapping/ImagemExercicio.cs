using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class ImagemExercicioMap : EntityTypeConfiguration<ImagemExercicio>
    {
        public ImagemExercicioMap()
        {
            // Primary Key
            this.HasKey(t => t.ImagemExercicioCodigo);

            // Properties
            this.Property(t => t.Url)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("ImagemExercicio", "hf");
            this.Property(t => t.ImagemExercicioCodigo).HasColumnName("ImagemExercicioCodigo");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.ExercicioCodigo).HasColumnName("ExercicioCodigo");
            this.Property(t => t.Situacao).HasColumnName("Situacao");

            // Relationships
            this.HasRequired(t => t.Exercicio)
                .WithMany(t => t.ImagemExercicioList)
                .HasForeignKey(d => d.ExercicioCodigo);

        }
    }
}
