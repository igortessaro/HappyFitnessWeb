using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;

namespace HF.Service.Business
{
    public class ExercicioService
    {
        public ExercicioService()
        {
            this.ExercicioRepository = new ExercicioRepository();
        }

        public ExercicioRepository ExercicioRepository { get; set; }

        public List<Exercicio> ObterTodosExercicios()
        {
            return this.ExercicioRepository.ConsultarTodos();
        }

        public string ObterPorParteDoNome(string like)
        {
            return this.ExercicioRepository.ConsultarLikeNome(like);
        }

    }
}
