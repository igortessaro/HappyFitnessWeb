using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class MusculoRepository : CrudRepository<HappyFitnessModel, Musculo>
    {
        public List<Musculo> ConsultarTodos()
        {
            IQueryable<Musculo> musculoQuery = this.Repository.Query<Musculo>().AsNoTracking();

            return musculoQuery.ToList();
        }

        public string ConsultarLikeNome(string like)
        {
            IQueryable<string> musculoQuery = this.Repository.Query<Musculo>()
                .Where(m => m.Nome.Contains(like))
                .OrderBy(m => m.Nome)
                .Select(m => m.Nome);

            return musculoQuery.FirstOrDefault();
        }
    }
}
