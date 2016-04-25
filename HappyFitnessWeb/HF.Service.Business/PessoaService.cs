using HF.DataTransferObject.Exercicio;
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

        public List<ExercicioDTO> ObterTreino(int pessoaCodigo)
        {
            return this.PessoaRepository.ObterTreino(pessoaCodigo);
        }
    }
}
