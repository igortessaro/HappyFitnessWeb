using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Exercicio
    {
        public Exercicio()
        {
            this.AparelhoExercicioList = new List<AparelhoExercicio>();
            this.MusculoExercicioList = new List<MusculoExercicio>();
        }

        public int ExercicioCodigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public ICollection<AparelhoExercicio> AparelhoExercicioList { get; set; }

        public ICollection<MusculoExercicio> MusculoExercicioList { get; set; }
    }
}
