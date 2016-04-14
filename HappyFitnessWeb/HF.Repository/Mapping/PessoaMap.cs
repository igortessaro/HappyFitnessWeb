using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            // Primary Key
            this.HasKey(t => t.codPessoa);

            // Tabela
            this.ToTable("Pessoa", "hf");
            this.Property(t => t.codPessoa).HasColumnName("codPessoa");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
        }
    }
}
