using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF.Domain.Entities
{
    public partial class ImagemExercicio
    {
        public int ImagemExercicio1 { get; set; }

        public string Url { get; set; }

        public int ExercicioCodigo { get; set; }

        public bool Situacao { get; set; }

        public Exercicio Exercicio { get; set; }
    }
}
