using HF.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HF.Repository.Mapping
{
    public class MusculoMap : EntityTypeConfiguration<Musculo>
    {
        public MusculoMap()
        {
            // Primary Key
            this.HasKey(t => t.MusculoCodigo);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Musculo", "hf");
            this.Property(t => t.MusculoCodigo).HasColumnName("MusculoCodigo");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
