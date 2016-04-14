using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class AparelhoService
    {
        public AparelhoService()
        {
            this.AparelhoRepository = new AparelhoRepository();
        }

        public AparelhoRepository AparelhoRepository { get; set; }

        public List<Aparelho> ObterTodosAparelhos()
        {
            return this.AparelhoRepository.ConsultarTodos();
        }

        public string ObterPorParteDoNome(string like)
        {
            return this.AparelhoRepository.ConsultarLikeNome(like);
        }

    }
}