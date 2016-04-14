using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class AtividadeRepository : CrudRepository<HappyFitnessModel, Atividade>
    {
        public List<Atividade> ConsultarTodos()
        {
            IQueryable<Atividade> atividadeQuery = this.Repository.Query<Atividade>().AsNoTracking();

            return atividadeQuery.ToList();
        }

    }
}
