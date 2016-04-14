using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.TreinoDiario
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.TreinoDiario>
    {
        public Expression<Func<Domain.Entities.TreinoDiario, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.TreinoDiario, bool>> Conditional(int id)
        {
            return x => x.codTreinoDiario == id;
        }
    }
}
