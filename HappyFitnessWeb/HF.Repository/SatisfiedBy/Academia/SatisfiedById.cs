using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.Academia
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.Academia>
    {
        public Expression<Func<Domain.Entities.Academia, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.Academia, bool>> Conditional(int id)
        {
            return x => x.AcademiaCodigo == id;
        }
    }
}
