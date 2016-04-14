using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class TreinoDiario
    {
        public TreinoDiario()
        {
            this.AtividadeList = new List<Atividade>();
        }

        public int TreinoDiarioCodigo { get; set; }

        public int TreinoCodigo { get; set; }

        public int? Tipo { get; set; }

        public ICollection<Atividade> AtividadeList { get; set; }

        public Treino Treino { get; set; }
    }
}
