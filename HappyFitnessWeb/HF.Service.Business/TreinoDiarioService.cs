using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class TreinoDiarioService
    {
        public TreinoDiarioService()
        {
            this.TreinoDiarioRepository = new TreinoDiarioRepository();
        }

        public TreinoDiarioRepository TreinoDiarioRepository { get; set; }

        public List<TreinoDiario> ObterTodosTreinosDiarios()
        {
            return this.TreinoDiarioRepository.ConsultarTodos();
        }

    }
}