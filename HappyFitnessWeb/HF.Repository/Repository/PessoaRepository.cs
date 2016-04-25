using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using HF.DataTransferObject.Exercicio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class PessoaRepository : CrudRepository<HappyFitnessModel, Pessoa>
    {
        public List<ExercicioDTO> ObterTreino(int pessoaCodigo = 1)
        {
            var query = this.Repository.Query<Treino>()
                .AsNoTracking()
                .Include(t => t.Aluno)
                .Include(t => t.TreinoDiarioList.Select(td => td.AtividadeList.Select(a => a.SerieList.Select(s => s.Exercicio))))
                .Where(t => t.AlunoCodigo == pessoaCodigo);

            return new List<ExercicioDTO>();
        }
    }
}
