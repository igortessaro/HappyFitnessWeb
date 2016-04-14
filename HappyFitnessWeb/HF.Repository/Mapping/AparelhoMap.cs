using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class AparelhoMap : EntityTypeConfiguration<Aparelho>
    {
        public AparelhoMap()
        {
            // Primary Key
            this.HasKey(t => t.AparelhoCodigo);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Aparelho", "hf");
            this.Property(t => t.AparelhoCodigo).HasColumnName("AparelhoCodigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
