namespace HF.Domain.Entities
{
    public partial class MusculoExercicio
    {
        public int MusculoExercicioCodigo { get; set; }

        public int MusculoCodigo { get; set; }

        public int ExercicioCodigo { get; set; }

        public Exercicio Exercicio { get; set; }

        public Musculo Musculo { get; set; }
    }
}
