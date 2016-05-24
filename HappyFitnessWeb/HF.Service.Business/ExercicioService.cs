using HF.DataTransferObject.Exercicio;
using HF.Domain.Entities;
using HF.Repository;
using System.Collections.Generic;
using System.Linq;

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
            List<Exercicio> exercicioList = this.ObterTodosExercicios();

            return exercicioList.Select(e => new ExercicioDTO
            {
                Nome = e.Nome,
                Icone = "Teste",
                QuantidadeRepeticoes = 10,
                QuantidadeSerie = 10
            }).ToList();
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
