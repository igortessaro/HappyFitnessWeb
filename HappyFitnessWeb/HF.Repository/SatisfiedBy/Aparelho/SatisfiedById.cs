using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.Aparelho
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.Aparelho>
    {
        public Expression<Func<Domain.Entities.Aparelho, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.Aparelho, bool>> Conditional(int id)
        {
            return x => x.codAparelho == id;
        }
    }
}
