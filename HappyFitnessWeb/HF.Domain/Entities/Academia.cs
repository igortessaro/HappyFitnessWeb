using System.Collections.Generic;

namespace HF.Domain.Entities
{
    public partial class Academia
    {
        public Academia()
        {
            this.PessoaAcademiaList = new List<PessoaAcademia>();
        }

        public int AcademiaCodigo { get; set; }

        public string Nome { get; set; }

        public ICollection<PessoaAcademia> PessoaAcademiaList { get; set; }
    }
}
