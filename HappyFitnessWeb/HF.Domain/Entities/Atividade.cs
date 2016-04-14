namespace HF.Domain.Entities
{
    public class Atividade
    {
        public int codAtividade { get; set; }

        public int codTreinoDiario { get; set; }

        public int Series { get; set; }

        public int Repeticoes { get; set; }

        public int codExercicio { get; set; }

        public int Peso { get; set; }

        public string Feedback { get; set; }
    }
}
