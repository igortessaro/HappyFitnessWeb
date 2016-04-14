using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Musculo
    {
        public Musculo()
        {
            this.MusculoExercicios = new List<MusculoExercicio>();
        }

        public int MusculoCodigo { get; set; }

        public string Nome { get; set; }

        public ICollection<MusculoExercicio> MusculoExercicios { get; set; }
    }
}
