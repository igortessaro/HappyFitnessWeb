using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.Exercicio
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.Exercicio>
    {
        public Expression<Func<Domain.Entities.Exercicio, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.Exercicio, bool>> Conditional(int id)
        {
            return x => x.ExercicioCodigo == id;
        }
    }
}
