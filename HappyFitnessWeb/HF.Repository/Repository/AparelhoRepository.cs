using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository.Repository
{
    public class AparelhoRepository : CrudRepository<HappyFitnessModel, Aparelho>
    {
        public List<Aparelho> ConsultarTodos()
        {
            IQueryable<Aparelho> academiaQuery = this.Repository.Query<Aparelho>().AsNoTracking();

            return academiaQuery.ToList();
        }

        public string ConsultarLikeNome(string like)
        {
            IQueryable<string> academiaQuery = this.Repository.Query<Aparelho>()
                .Where(a => a.Nome.Contains(like))
                .OrderBy(a => a.Nome)
                .Select(a => a.Nome);

            return academiaQuery.FirstOrDefault();
        }
    }
}
