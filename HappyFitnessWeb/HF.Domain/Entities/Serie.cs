using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Serie
    {
        public Serie()
        {
            this.AtividadeList = new List<Atividade>();
        }

        public int SerieCodigo { get; set; }

        public int? Repeticoes { get; set; }

        public decimal? Peso { get; set; }

        public int? TempoSegundos { get; set; }

        public int ExercicioCodigo { get; set; }

        public ICollection<Atividade> AtividadeList { get; set; }
    }
}
