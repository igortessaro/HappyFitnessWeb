namespace HF.Domain.Entities
{
    public partial class PessoaAcademia
    {
        public int PessoaAcademiaCodigo { get; set; }

        public int PessoaCodigo { get; set; }

        public int AcademiaCodigo { get; set; }

        public bool Situacao { get; set; }

        public Academia Academia { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
