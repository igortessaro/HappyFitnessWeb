using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class TreinoMap : EntityTypeConfiguration<Treino>
    {
        public TreinoMap()
        {
            // Primary Key
            this.HasKey(t => t.codTreino);

            // Tabela
            this.ToTable("Treino", "hf");
            this.Property(t => t.codTreino).HasColumnName("codTreino");
            this.Property(t => t.codAluno).HasColumnName("codAluno");
            this.Property(t => t.codInstrutor).HasColumnName("codInstrutor");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.dataInicio).HasColumnName("dataInicio");
            this.Property(t => t.dataFim).HasColumnName("dataFim");
        }
    }
}
