using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class TreinoRepository : CrudRepository<HappyFitnessModel, Treino>
    {
        public List<Treino> ConsultarTodos()
        {
            IQueryable<Treino> treinoQuery = this.Repository.Query<Treino>().AsNoTracking();

            return treinoQuery.ToList();
        }

    }
}
