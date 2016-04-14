using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class AtividadeService
    {
        public AtividadeService()
        {
            this.AtividadeRepository = new AtividadeRepository();
        }

        public AtividadeRepository AtividadeRepository { get; set; }

        public List<Atividade> ObterTodasAtividades()
        {
            return this.AtividadeRepository.ConsultarTodos();
        }

    }
}