using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Serie
    {
        public int SerieCodigo { get; set; }

        public int? Repeticoes { get; set; }

        public decimal? Peso { get; set; }

        public int? TempoSegundos { get; set; }

        public int ExercicioCodigo { get; set; }

        public int AtividadeCodigo { get; set; }

        public int Ordem { get; set; }

        public Atividade Atividade { get; set; }

        public Exercicio Exercicio { get; set; }
    }
}
