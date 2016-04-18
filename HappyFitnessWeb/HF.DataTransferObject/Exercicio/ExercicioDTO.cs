using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF.DataTransferObject.Exercicio
{
    public class ExercicioDTO
    {
        public string Icone { get; set; }

        public string Nome { get; set; }

        public int QuantidadeSerie { get; set; }

        public int QuantidadeRepeticoes { get; set; }

        public void SetDefault(int value)
        {
            this.Icone = "img/fitness-training-311490_960_720.png";
            this.Nome = $"Exercicio {value}";
            this.QuantidadeRepeticoes = 15;
            this.QuantidadeSerie = 4;
        }
    }
}
