using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.Musculo
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.Musculo>
    {
        public Expression<Func<Domain.Entities.Musculo, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.Musculo, bool>> Conditional(int id)
        {
            return x => x.MusculoCodigo == id;
        }
    }
}
