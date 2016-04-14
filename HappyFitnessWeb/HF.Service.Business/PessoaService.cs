using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class PessoaService
    {
        public PessoaService()
        {
            this.PessoaRepository = new PessoaRepository();
        }

        public PessoaRepository PessoaRepository { get; set; }

        public List<Pessoa> ObterTodasPessoas()
        {
            return this.PessoaRepository.ConsultarTodos();
        }

        public string ObterPorParteDoNome(string like)
        {
            return this.PessoaRepository.ConsultarLikeNome(like);
        }

    }
}
