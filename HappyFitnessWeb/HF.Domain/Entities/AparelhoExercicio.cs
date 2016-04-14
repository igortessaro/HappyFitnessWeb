namespace HF.Domain.Entities
{
    public partial class AparelhoExercicio
    {
        public int AparelhoExercicioCodigo { get; set; }

        public int ExercicioCodigo { get; set; }

        public int AparelhoCodigo { get; set; }

        public Aparelho Aparelho { get; set; }

        public Exercicio Exercicio { get; set; }
    }
}
