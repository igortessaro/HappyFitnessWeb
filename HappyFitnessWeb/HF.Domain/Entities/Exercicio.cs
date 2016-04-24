using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Exercicio
    {
        public Exercicio()
        {
            this.AparelhoExercicioList = new List<AparelhoExercicio>();
            this.ImagemExercicioList = new List<ImagemExercicio>();
            this.MusculoExercicioList = new List<MusculoExercicio>();
            this.SerieList = new List<Serie>();
        }

        public int ExercicioCodigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<AparelhoExercicio> AparelhoExercicioList { get; set; }

        public virtual ICollection<ImagemExercicio> ImagemExercicioList { get; set; }

        public virtual ICollection<MusculoExercicio> MusculoExercicioList { get; set; }

        public virtual ICollection<Serie> SerieList { get; set; }
    }
}
