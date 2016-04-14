using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Treino
    {
        public Treino()
        {
            this.TreinoDiarios = new List<TreinoDiario>();
        }

        public int TreinoCodigo { get; set; }

        public int AlunoCodigo { get; set; }

        public int InstrutorCodigo { get; set; }

        public int Tipo { get; set; }

        public System.DateTime DataHoraInicio { get; set; }

        public System.DateTime DataHoraFim { get; set; }

        public Pessoa Pessoa { get; set; }

        public Pessoa Pessoa1 { get; set; }

        public ICollection<TreinoDiario> TreinoDiarios { get; set; }
    }
}
