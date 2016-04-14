using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.Treino
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.Treino>
    {
        public Expression<Func<Domain.Entities.Treino, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.Treino, bool>> Conditional(int id)
        {
            return x => x.TreinoCodigo == id;
        }
    }
}
