using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class ExercicioRepository : CrudRepository<HappyFitnessModel, Exercicio>
    {
        public List<Exercicio> ConsultarTodos()
        {
            IQueryable<Exercicio> exercicioQuery = this.Repository.Query<Exercicio>().AsNoTracking();

            return exercicioQuery.ToList();
        }
        public string ConsultarLikeNome(string like)
        {
            IQueryable<string> exercicioQuery = this.Repository.Query<Exercicio>()
                .Where(e => e.Nome.Contains(like))
                .OrderBy(e => e.Nome)
                .Select(e => e.Nome);

            return exercicioQuery.FirstOrDefault();
        }

    }
}
