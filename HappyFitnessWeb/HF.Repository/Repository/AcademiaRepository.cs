using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class AcademiaRepository : CrudRepository<HappyFitnessModel, Academia>
    {
        public List<Academia> ConsultarTodos()
        {
            IQueryable<Academia> academiaQuery = this.Repository.Query<Academia>().AsNoTracking();

            return academiaQuery.ToList();
        }

        public string ConsultarLikeNome(string like)
        {
            IQueryable<string> academiaQuery = this.Repository.Query<Academia>()
                .Where(a => a.Nome.Contains(like))
                .OrderBy(a => a.Nome)
                .Select(a => a.Nome);

            return academiaQuery.FirstOrDefault();
        }
    }
}
