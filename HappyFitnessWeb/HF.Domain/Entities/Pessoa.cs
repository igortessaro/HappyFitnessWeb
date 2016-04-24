using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            this.PessoaAcademiaList = new List<PessoaAcademia>();
            //this.Treinoes = new List<Treino>();
            //this.Treinoes1 = new List<Treino>();
        }

        public int PessoaCodigo { get; set; }

        public string Nome { get; set; }

        public int Tipo { get; set; }

        public bool Situacao { get; set; }

        public ICollection<PessoaAcademia> PessoaAcademiaList { get; set; }

        //public ICollection<Treino> Treinoes { get; set; }

        //public ICollection<Treino> Treinoes1 { get; set; }
    }
}
