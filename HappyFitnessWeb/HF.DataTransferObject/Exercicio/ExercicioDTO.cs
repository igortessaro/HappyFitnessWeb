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

        List<ExercicioDTO> Exercicio = this.Repository.Query<Exercicio>()
             .AsNoTracking()

             .Include(imgEx => imgEx.ImagemExercicio)
             .Include(sr => sr.Serie)

             .Select(imgEx => new ListaEx
             {
                 this.Icone = imgEx.Url,
                 this.Nome = Nome,
                 this.QuantidadeRepeticoes = sr.Repeticoes
             })
             .ToList();

    }
}
