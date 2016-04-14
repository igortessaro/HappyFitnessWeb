using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            // Primary Key
            this.HasKey(t => t.PessoaCodigo);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("Pessoa", "hf");
            this.Property(t => t.PessoaCodigo).HasColumnName("PessoaCodigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
        }
    }
}
