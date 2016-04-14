namespace HF.Domain.Entities
{
    public partial class Atividade
    {
        public int AtividadeCodigo { get; set; }

        public int TreinoDiarioCodigo { get; set; }

        public int SerieCodigo { get; set; }

        public int? Feedback { get; set; }

        public Serie Serie { get; set; }

        public TreinoDiario TreinoDiario { get; set; }
    }
}
