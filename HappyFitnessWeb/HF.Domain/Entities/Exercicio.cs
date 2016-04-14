using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Exercicio
    {
        public Exercicio()
        {
            this.AparelhoExercicios = new List<AparelhoExercicio>();
            this.MusculoExercicios = new List<MusculoExercicio>();
        }

        public int ExercicioCodigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public ICollection<AparelhoExercicio> AparelhoExercicios { get; set; }

        public ICollection<MusculoExercicio> MusculoExercicios { get; set; }
    }
}
