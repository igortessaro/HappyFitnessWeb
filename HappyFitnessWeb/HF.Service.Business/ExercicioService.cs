using HF.DataTransferObject.Exercicio;
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

        public List<ExercicioDTO> ObterExercicos(int pessoaCodigo)
        {
            List<ExercicioDTO> result = new List<ExercicioDTO>();

            for (int i = 0; i < 15; i++)
            {
                ExercicioDTO e = new ExercicioDTO();
                e.SetDefault(i);
                result.Add(e);
            }

            return result;
        }

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
