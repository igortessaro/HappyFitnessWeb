using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Musculo
    {
        public Musculo()
        {
            this.MusculoExercicioList = new List<MusculoExercicio>();
        }

        public int MusculoCodigo { get; set; }

        public string Nome { get; set; }

        public ICollection<MusculoExercicio> MusculoExercicioList { get; set; }
    }
}
