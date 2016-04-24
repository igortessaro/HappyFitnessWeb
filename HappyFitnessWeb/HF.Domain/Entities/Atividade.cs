using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Atividade
    {
        public Atividade()
        {
            this.SerieList = new List<Serie>();
        }

        public int AtividadeCodigo { get; set; }

        public int TreinoDiarioCodigo { get; set; }

        public int? Feedback { get; set; }

        public virtual TreinoDiario TreinoDiario { get; set; }

        public virtual ICollection<Serie> SerieList { get; set; }
    }
}
