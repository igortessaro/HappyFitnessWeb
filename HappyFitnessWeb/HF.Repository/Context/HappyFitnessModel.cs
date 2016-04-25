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

        public DbSet<Academia> Academias { get; set; }

        public DbSet<Aparelho> Aparelhoes { get; set; }

        public DbSet<AparelhoExercicio> AparelhoExercicios { get; set; }

        public DbSet<Atividade> Atividades { get; set; }

        public DbSet<Exercicio> Exercicios { get; set; }

        public DbSet<Musculo> Musculoes { get; set; }

        public DbSet<MusculoExercicio> MusculoExercicios { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<PessoaAcademia> PessoaAcademias { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Treino> Treinoes { get; set; }

        public DbSet<TreinoDiario> TreinoDiarios { get; set; }

        public DbSet<ImagemExercicio> ImagemExercicios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AcademiaMap());
            modelBuilder.Configurations.Add(new AparelhoMap());
            modelBuilder.Configurations.Add(new AparelhoExercicioMap());
            modelBuilder.Configurations.Add(new AtividadeMap());
            modelBuilder.Configurations.Add(new ExercicioMap());
            modelBuilder.Configurations.Add(new MusculoMap());
            modelBuilder.Configurations.Add(new MusculoExercicioMap());
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new PessoaAcademiaMap());
            modelBuilder.Configurations.Add(new SerieMap());
            modelBuilder.Configurations.Add(new TreinoMap());
            modelBuilder.Configurations.Add(new TreinoDiarioMap());
            modelBuilder.Configurations.Add(new ImagemExercicioMap());
        }
    }
}
