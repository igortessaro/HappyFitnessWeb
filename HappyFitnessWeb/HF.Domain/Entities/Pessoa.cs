using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            this.PessoaAcademias = new List<PessoaAcademia>();
            this.Treinoes = new List<Treino>();
            this.Treinoes1 = new List<Treino>();
        }

        public int PessoaCodigo { get; set; }

        public string Nome { get; set; }

        public int Tipo { get; set; }

        public virtual ICollection<PessoaAcademia> PessoaAcademias { get; set; }

        public virtual ICollection<Treino> Treinoes { get; set; }

        public virtual ICollection<Treino> Treinoes1 { get; set; }
    }
}
