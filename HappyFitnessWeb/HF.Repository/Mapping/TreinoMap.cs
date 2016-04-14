using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class TreinoMap : EntityTypeConfiguration<Treino>
    {
        public TreinoMap()
        {
            // Primary Key
            this.HasKey(t => t.TreinoCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("Treino", "hf");
            this.Property(t => t.TreinoCodigo).HasColumnName("TreinoCodigo");
            this.Property(t => t.AlunoCodigo).HasColumnName("AlunoCodigo");
            this.Property(t => t.InstrutorCodigo).HasColumnName("InstrutorCodigo");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.DataHoraInicio).HasColumnName("DataHoraInicio");
            this.Property(t => t.DataHoraFim).HasColumnName("DataHoraFim");

            // Relationships
            this.HasRequired(t => t.Pessoa)
                .WithMany(t => t.Treinoes)
                .HasForeignKey(d => d.AlunoCodigo);
            this.HasRequired(t => t.Pessoa1)
                .WithMany(t => t.Treinoes1)
                .HasForeignKey(d => d.InstrutorCodigo);

        }
    }
}
