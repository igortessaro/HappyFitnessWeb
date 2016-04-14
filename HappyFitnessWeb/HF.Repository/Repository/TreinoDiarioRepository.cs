using HF.Domain.Entities;
using HF.Repository.Context;
using HF.Repository.Generic;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HF.Repository
{
    public class TreinoDiarioRepository : CrudRepository<HappyFitnessModel, TreinoDiario>
    {
        public List<TreinoDiario> ConsultarTodos()
        {
            IQueryable<TreinoDiario> treinoDiarioQuery = this.Repository.Query<TreinoDiario>().AsNoTracking();

            return treinoDiarioQuery.ToList();
        }

    }
}
