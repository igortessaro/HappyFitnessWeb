using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class PessoaAcademiaMap : EntityTypeConfiguration<PessoaAcademia>
    {
        public PessoaAcademiaMap()
        {
            // Primary Key
            this.HasKey(t => t.PessoaAcademiaCodigo);

            // Properties
            // Table & Column Mappings
            this.ToTable("PessoaAcademia", "hf");
            this.Property(t => t.PessoaAcademiaCodigo).HasColumnName("PessoaAcademiaCodigo");
            this.Property(t => t.PessoaCodigo).HasColumnName("PessoaCodigo");
            this.Property(t => t.AcademiaCodigo).HasColumnName("AcademiaCodigo");
            this.Property(t => t.Situacao).HasColumnName("Situacao");

            // Relationships
            this.HasRequired(t => t.Academia)
                .WithMany(t => t.PessoaAcademias)
                .HasForeignKey(d => d.AcademiaCodigo);
            this.HasRequired(t => t.Pessoa)
                .WithMany(t => t.PessoaAcademias)
                .HasForeignKey(d => d.PessoaCodigo);

        }
    }
}
