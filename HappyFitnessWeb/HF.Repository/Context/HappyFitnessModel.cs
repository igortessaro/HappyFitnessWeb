using HF.Domain.Entities;
using HF.Repository.Mapping;
using System.Data.Entity;

namespace HF.Repository.Context
{
    public class HappyFitnessModel : DbContext
    {
        static HappyFitnessModel()
        {
            Database.SetInitializer<HappyFitnessModel>(null);
        }

        public HappyFitnessModel()
            : base("Name=HappyFitnessModel")
        {
        }

        public DbSet<Academia> Academias
        { get; set; }
        public DbSet<Aparelho> Aparelhos
        { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AcademiaMap());
            modelBuilder.Configurations.Add(new AparelhoMap());

        }
       
    }
}
