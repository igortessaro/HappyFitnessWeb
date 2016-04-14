using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class MusculoService
    {
        public MusculoService()
        {
            this.MusculoRepository = new MusculoRepository();
        }

        public MusculoRepository MusculoRepository { get; set; }

        public List<Musculo> ObterTodosMusculos()
        {
            return this.MusculoRepository.ConsultarTodos();
        }

        public string ObterPorParteDoNome(string like)
        {
            return this.MusculoRepository.ConsultarLikeNome(like);
        }

    }
}
