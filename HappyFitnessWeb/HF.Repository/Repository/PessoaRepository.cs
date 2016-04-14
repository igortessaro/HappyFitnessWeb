using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class PessoaRepository : CrudRepository<HappyFitnessModel, Pessoa>
    {
        public List<Pessoa> ConsultarTodos()
        {
            IQueryable<Pessoa> pessoaQuery = this.Repository.Query<Pessoa>().AsNoTracking();

            return pessoaQuery.ToList();
        }

        public string ConsultarLikeNome(string like)
        {
            IQueryable<string> pessoaQuery = this.Repository.Query<Pessoa>()
                .Where(p => p.Nome.Contains(like))
                .OrderBy(p => p.Nome)
                .Select(p => p.Nome);

            return pessoaQuery.FirstOrDefault();
        }
    }
}
