using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class AparelhoMap : EntityTypeConfiguration<Aparelho>
    {
        public AparelhoMap()
        {
            // Primary Key
            this.HasKey(t => t.codAparelho);

            // Tabela
            this.ToTable("Aparelho", "hf");
            this.Property(t => t.codAparelho).HasColumnName("codAparelho");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}

