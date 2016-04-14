using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class TreinoService
    {
        public TreinoService()
        {
            this.TreinoRepository = new TreinoRepository();
        }

        public TreinoRepository TreinoRepository { get; set; }

        public List<Treino> ObterTodosTreinos()
        {
            return this.TreinoRepository.ConsultarTodos();
        }

    }
}
