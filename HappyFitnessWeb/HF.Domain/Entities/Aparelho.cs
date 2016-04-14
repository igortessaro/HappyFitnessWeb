using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Aparelho
    {
        public Aparelho()
        {
            this.AparelhoExercicioList = new List<AparelhoExercicio>();
        }

        public int AparelhoCodigo { get; set; }

        public string Nome { get; set; }

        public ICollection<AparelhoExercicio> AparelhoExercicioList { get; set; }
    }
}
